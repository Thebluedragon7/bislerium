using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class CommentSqlRepository : ICommentRepository
{
    private readonly BisleriumContext _db;

    public CommentSqlRepository(BisleriumContext db)
    {
        _db = db;
    }

    public IEnumerable<Comment> GetAllComments()
    {
        return _db.Comments
            .Include(c => c.User)
            .Include(c => c.CommentReactions)
            .ToList();
    }

    public void AddComment(Comment comment)
    {
        _db.Comments.Add(comment);
        _db.SaveChanges();
    }

    public IEnumerable<Comment> GetCommentsByBlogId(Guid blogId)
    {
        return _db.Comments.Where(c => c.BlogId == blogId)
            .Include(c => c.User)
            .Include(c => c.CommentReactions)
            .ToList();
    }

    public void UpdateComment(Guid commentId, Comment comment)
    {
        var existingComment = _db.Comments.Find(commentId);
        if (existingComment == null) return;

        existingComment.Text = comment.Text;
        existingComment.UpdatedAt = comment.UpdatedAt;

        _db.SaveChanges();
    }

    public Comment? GetCommentById(Guid commentId)
    {
        return _db.Comments
            .FirstOrDefault(c => c.Id == commentId);
    }

    public void DeleteComment(Guid commentId)
    {
        var comment = _db.Comments.Find(commentId);
        if (comment == null) return;

        _db.Comments.Remove(comment);
        _db.SaveChanges();
    }

    public int GetCommentCountByMonth(DateTime? month)
    {
        if (month != null)
        {
            return _db.Comments
                .Count(c => c.CreatedAt.Month == month.Value.Month && c.CreatedAt.Year == month.Value.Year);
        }

        return _db.Comments.Count();
    }
}