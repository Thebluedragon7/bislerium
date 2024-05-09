using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class BlogImageSqlRepository : IBlogImageRepository
{
    private readonly BisleriumContext _db;

    public BlogImageSqlRepository(BisleriumContext db)
    {
        _db = db;
    }
    public void AddBlogImages(Guid blogId, List<BlogImage> blogImages)
    {
        _db.BlogImages.AddRange(blogImages);
        _db.SaveChanges();
    }

    public IEnumerable<BlogImage> GetBlogImages(Guid blogId)
    {
        return _db.BlogImages.Where(x => x.BlogId == blogId).ToList();
    }

    public void DeleteBlogImage(Guid blogId, Guid blogImageId)
    {
        var blogImage = _db.BlogImages.Find(blogImageId);
        if (blogImage == null) return;

        _db.BlogImages.Remove(blogImage);
        _db.SaveChanges();
    }
}