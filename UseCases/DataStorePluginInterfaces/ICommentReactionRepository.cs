using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface ICommentReactionRepository
{
    void AddCommentReaction(CommentReaction commentReaction);
    void DeleteCommentReaction(Guid commentReactionId);
}