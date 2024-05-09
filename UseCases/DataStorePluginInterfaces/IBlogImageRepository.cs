using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface IBlogImageRepository
{
    void AddBlogImages(Guid blogId, List<BlogImage> blogImages);
    IEnumerable<BlogImage> GetBlogImages(Guid blogId);
    BlogImage? GetBlogImage(Guid blogImageId);
    void DeleteBlogImage(Guid blogImageId);
}