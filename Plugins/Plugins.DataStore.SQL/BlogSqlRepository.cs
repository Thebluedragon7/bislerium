using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class BlogSqlRepository : IBlogRepository
{
    private readonly BisleriumContext _db;

    public BlogSqlRepository(BisleriumContext db)
    {
        _db = db;
    }

    public void AddBlog(Blog blog)
    {
        _db.Blogs.Add(blog);
        _db.SaveChanges();
    }

    public IEnumerable<Blog> GetBlogs()
    {
        return _db.Blogs.ToList();
    }

    public Blog? GetBlogById(Guid blogId)
    {
        return _db.Blogs.Find(blogId);
    }

    public void UpdateBlog(Guid blogId, Blog blog)
    {
        var existingBlog = _db.Blogs.Find(blogId);
        if (existingBlog == null) return;

        existingBlog.Title = blog.Title;
        existingBlog.Body = blog.Body;

        if (blog.Subtitle != null)
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
}