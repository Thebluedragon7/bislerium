using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface ICommentRepository
{
    void AddComment(Comment comment);
    void DeleteComment(Guid commentId);
}