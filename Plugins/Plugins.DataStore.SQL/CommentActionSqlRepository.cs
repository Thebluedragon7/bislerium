using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class CommentActionSqlRepository : ICommentActionRepository
{
    private readonly BisleriumContext _db;

    public CommentActionSqlRepository(BisleriumContext db)
    {
        _db = db;
    }

    public void AddCommentAction(CommentAction commentAction)
    {
        _db.CommentActions.Add(commentAction);
        _db.SaveChanges();
    }

    public IEnumerable<CommentAction> GetCommentActionsByCommentId(Guid commentId)
    {
        return _db.CommentActions.Where(x => x.CommentId == commentId).ToList();
    }
}