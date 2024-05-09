using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface ICommentRepository
{
    void AddComment(Comment comment);
    IEnumerable<Comment> GetCommentsByBlogId(Guid blogId);
    void DeleteComment(Guid commentId);
}