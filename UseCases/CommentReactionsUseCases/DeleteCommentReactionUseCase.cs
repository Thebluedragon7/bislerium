using UseCases.DataStorePluginInterfaces;

namespace UseCases.CommentReactionsUseCases;

public class DeleteCommentReactionUseCase : IDeleteCommentReactionUseCase
{
    private readonly ICommentReactionRepository _commentReactionRepository;

    public DeleteCommentReactionUseCase(ICommentReactionRepository commentReactionRepository)
    {
        this._commentReactionRepository = commentReactionRepository;
    }
    
    public void Execute(Guid commentReactionId)
    {
        _commentReactionRepository.DeleteCommentReaction(commentReactionId);
    }
}