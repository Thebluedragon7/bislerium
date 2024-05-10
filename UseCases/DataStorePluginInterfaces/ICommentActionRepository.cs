using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface ICommentActionRepository
{
    void AddCommentAction(CommentAction commentAction);
    IEnumerable<CommentAction> GetCommentActionsByCommentId(Guid commentId);
}