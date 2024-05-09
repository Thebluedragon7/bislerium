namespace UseCases.CommentsUseCases;

public interface IDeleteCommentUseCase
{
    void Execute(Guid commentId);
}