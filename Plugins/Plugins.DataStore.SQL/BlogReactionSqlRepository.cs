using CoreBusiness;
using Plugins.DataStore.SQL.constants;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class BlogReactionSqlRepository : IBlogReactionRepository
{
    private readonly BisleriumContext _db;

    public BlogReactionSqlRepository(BisleriumContext db)
    {
        _db = db;
    }

    public void AddBlogReaction(BlogReaction blogReaction)
    {
        _db.BlogReactions.Add(blogReaction);
        _db.SaveChanges();
    }

    public IEnumerable<BlogReaction> GetBlogReactionsByBlogId(Guid blogId)
    {
        return _db.BlogReactions
            .Where(br => br.BlogId == blogId)
            .ToList();
    }

    public void DeleteBlogReaction(Guid blogReactionId)
    {
        var blogReaction = _db.BlogReactions.Find(blogReactionId);
        if (blogReaction == null) return;

        _db.BlogReactions.Remove(blogReaction);
        _db.SaveChanges();
    }

    public int GetUpvotesByMonth(DateTime? month)
    {
        IQueryable<BlogReaction> query =
            _db.BlogReactions.Where(br => br.ReactionTypeId == Guid.Parse(ReactionTypeMapper.UPVOTE));

        if (month != null)
        {
            query = query.Where(br => br.CreatedAt.Month == month.Value.Month && br.CreatedAt.Year == month.Value.Year);
        }

        return query.Count();
    }

    public int GetDownvotesByMonth(DateTime? month)
    {
        IQueryable<BlogReaction> query =
            _db.BlogReactions.Where(br => br.ReactionTypeId == Guid.Parse(ReactionTypeMapper.DOWNVOTE));

        if (month != null)
        {
            query = query.Where(br => br.CreatedAt.Month == month.Value.Month && br.CreatedAt.Year == month.Value.Year);
        }

        return query.Count();
    }
}