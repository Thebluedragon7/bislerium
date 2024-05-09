using UseCases.DataStorePluginInterfaces;

namespace UseCases.CommentsUseCases;

public class DeleteCommentUseCase : IDeleteCommentUseCase
{
    private readonly ICommentRepository _commentRepository;

    public DeleteCommentUseCase(ICommentRepository commentRepository)
    {
        this._commentRepository = commentRepository;
    }

    public void Execute(Guid commentId)
    {
        _commentRepository.DeleteComment(commentId);
    }
}