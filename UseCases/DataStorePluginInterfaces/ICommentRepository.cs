using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface ICommentRepository
{
    void AddComment(Comment comment);
    IEnumerable<Comment> GetCommentsByBlogId(Guid blogId);
    void UpdateComment(Guid commentId, Comment comment);
    Comment? GetCommentById(Guid commentId);
    void DeleteComment(Guid commentId);
    int GetCommentCountByMonth(DateTime? month);
}