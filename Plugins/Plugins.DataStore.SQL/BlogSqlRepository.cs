using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.SQL.constants;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class BlogSqlRepository : IBlogRepository
{
    private readonly BisleriumContext _db;

    public BlogSqlRepository(BisleriumContext db)
    {
        _db = db;
    }

    public IEnumerable<Blog> GetAllBlogs()
    {
        return _db.Blogs.Include(b => b.Author).ToList();
    }

    public void AddBlog(Blog blog)
    {
        _db.Blogs.Add(blog);
        _db.SaveChanges();
    }

    public IEnumerable<Blog> GetBlogs(int pageNumber, int pageSize, String sortBy)
    {
        int skip = (pageNumber - 1) * pageSize;

        IQueryable<Blog> query = _db.Blogs.Include(b => b.Author);

        switch (sortBy.ToLower())
        {
            case "recency":
                query = query.OrderByDescending(b => b.CreatedAt);
                break;
            case "popularity":
                query = query.OrderByDescending(b =>
                    b.BlogReactions.Count(br => br.ReactionTypeId == Guid.Parse(ReactionTypeMapper.UPVOTE)) * 2 +
                    b.BlogReactions.Count(br => br.ReactionTypeId == Guid.Parse(ReactionTypeMapper.DOWNVOTE)) * -1 +
                    b.Comments.Count);
                break;
            default:
                query = query.OrderBy(b => Guid.NewGuid()); // Random sorting
                break;
        }

        query = query.Skip(skip).Take(pageSize);

        return query.ToList();
    }

    public Blog? GetBlogById(Guid blogId)
    {
        return _db.Blogs
            .Include(b => b.Author)
            .Include(b => b.BlogImages)
            .FirstOrDefault(b => b.Id == blogId);
    }

    public void UpdateBlog(Guid blogId, Blog blog)
    {
        var existingBlog = _db.Blogs.Find(blogId);
        if (existingBlog == null) return;

        existingBlog.Title = blog.Title;
        existingBlog.Body = blog.Body;
        existingBlog.Subtitle = blog.Subtitle;
        existingBlog.UpdatedAt = DateTime.Now;

        _db.SaveChanges();
    }

    public void DeleteBlog(Guid blogId)
    {
        var blog = _db.Blogs.Find(blogId);
        if (blog == null) return;

        _db.Blogs.Remove(blog);
        _db.SaveChanges();
    }

    public IEnumerable<Blog> GetTop10Blogs(DateTime? month)
    {
        IQueryable<Blog> query = _db.Blogs.Include(b => b.Author);

        query = query.OrderByDescending(b =>
            b.BlogReactions.Count(br => br.ReactionTypeId == Guid.Parse(ReactionTypeMapper.UPVOTE)) * 2 +
            b.BlogReactions.Count(br => br.ReactionTypeId == Guid.Parse(ReactionTypeMapper.DOWNVOTE)) * -1 +
            b.Comments.Count);

        if (month != null)
        {
            query = query.Where(b => b.CreatedAt.Month == month.Value.Month && b.CreatedAt.Year == month.Value.Year);
        }

        return query.OrderByDescending(b => b.CreatedAt).Take(10).ToList();
    }

    public int GetTotalBlogs(DateTime? month)
    {
        IQueryable<Blog> query = _db.Blogs;

        if (month != null)
        {
            query = query.Where(b => b.CreatedAt.Month == month.Value.Month && b.CreatedAt.Year == month.Value.Year);
        }

        return query.Count();
    }

    public IEnumerable<BloggerInfo> GetTop10Bloggers(DateTime? month)
    {
        IQueryable<Blog> query = _db.Blogs.Include(b => b.Author);

        if (month != null)
        {
            query = query.Where(b => b.CreatedAt.Month == month.Value.Month && b.CreatedAt.Year == month.Value.Year);
        }

        return query
            .GroupBy(b => b.Author)
            .OrderByDescending(g => g.Count())
            .Take(10)
            .Select(g => new BloggerInfo { FullName = g.Key.FullName, Email = g.Key.Email })
            .ToList();
    }
}