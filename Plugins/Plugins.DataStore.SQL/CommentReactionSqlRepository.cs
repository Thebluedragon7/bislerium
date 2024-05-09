using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class CommentReactionSqlRepository : ICommentReactionRepository
{
    private readonly BisleriumContext _db;

    public CommentReactionSqlRepository(BisleriumContext db)
    {
        _db = db;
    }


    public void AddCommentReaction(CommentReaction commentReaction)
    {
        _db.CommentReactions.Add(commentReaction);
        _db.SaveChanges();
    }

    public void DeleteCommentReaction(Guid commentReactionId)
    {
        var commentReaction = _db.CommentReactions.Find(commentReactionId);
        if (commentReaction == null) return;

        _db.CommentReactions.Remove(commentReaction);
        _db.SaveChanges();
    }
}