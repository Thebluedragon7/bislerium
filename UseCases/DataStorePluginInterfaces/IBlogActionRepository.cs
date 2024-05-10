using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface IBlogActionRepository
{
    void AddBlogAction(BlogAction blogAction);
    IEnumerable<BlogAction> GetBlogActionsByBlogId(Guid blogId);
}