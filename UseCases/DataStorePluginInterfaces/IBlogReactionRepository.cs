using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface IBlogReactionRepository
{
    void AddBlogReaction(BlogReaction blogReaction);
    IEnumerable<BlogReaction> GetBlogReactionsByBlogId(Guid blogId);
    void DeleteBlogReaction(Guid blogReactionId);
}