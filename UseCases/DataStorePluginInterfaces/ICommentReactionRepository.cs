using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface ICommentReactionRepository
{
    void AddCommentReaction(CommentReaction commentReaction);
    IEnumerable<CommentReaction> GetCommentReactionsByCommentId(Guid commentId);
    void DeleteCommentReaction(Guid commentReactionId);
}