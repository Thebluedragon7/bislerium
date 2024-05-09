using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class CommentSqlRepository : ICommentRepository
{
    private readonly BisleriumContext _db;

    public CommentSqlRepository(BisleriumContext db)
    {
        _db = db;
    }

    public void AddComment(Comment comment)
    {
        _db.Comments.Add(comment);
        _db.SaveChanges();
    }

    public void DeleteComment(Guid commentId)
    {
        var comment = _db.Comments.Find(commentId);
        if (comment == null) return;

        _db.Comments.Remove(comment);
        _db.SaveChanges();
    }
}