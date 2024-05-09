using CoreBusiness;
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

    public void DeleteBlogReaction(Guid blogReactionId)
    {
        var blogReaction = _db.BlogReactions.Find(blogReactionId);
        if (blogReaction == null) return;

        _db.BlogReactions.Remove(blogReaction);
        _db.SaveChanges();
    }
}