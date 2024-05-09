using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface IBlogReactionRepository
{
    void AddBlogReaction(BlogReaction blogReaction);
    IEnumerable<BlogReaction> GetBlogReactionsByBlogId(Guid blogId);
    void DeleteBlogReaction(Guid blogReactionId);
    int GetUpvotesByMonth(DateTime? month);
    int GetDownvotesByMonth(DateTime? month);
}