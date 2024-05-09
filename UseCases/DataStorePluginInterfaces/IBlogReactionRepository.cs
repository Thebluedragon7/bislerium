using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface IBlogReactionRepository
{
    void AddBlogReaction(BlogReaction blogReaction);
    void DeleteBlogReaction(Guid blogReactionId);
}