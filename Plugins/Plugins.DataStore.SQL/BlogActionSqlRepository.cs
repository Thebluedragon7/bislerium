using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class BlogActionSqlRepository : IBlogActionRepository
{
    private readonly BisleriumContext _db;

    public BlogActionSqlRepository(BisleriumContext db)
    {
        _db = db;
    }

    public void AddBlogAction(BlogAction blogAction)
    {
        _db.BlogActions.Add(blogAction);
        _db.SaveChanges();
    }

    public IEnumerable<BlogAction> GetBlogActionsByBlogId(Guid blogId)
    {
        return _db.BlogActions.Where(x => x.BlogId == blogId).ToList();
    }
}