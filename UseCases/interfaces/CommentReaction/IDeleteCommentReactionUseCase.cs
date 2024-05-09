namespace UseCases.CommentReactionsUseCases;

public interface IDeleteCommentReactionUseCase
{
    void Execute(Guid commentReactionId);
}