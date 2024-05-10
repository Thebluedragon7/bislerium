using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CommentsUseCases;

public class UpdateCommentUseCase : IUpdateCommentUseCase
{
    private readonly ICommentRepository _commentRepository;

    public UpdateCommentUseCase(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public void Execute(Guid commentId, Comment comment)
    {
        _commentRepository.UpdateComment(commentId, comment);
    }
}