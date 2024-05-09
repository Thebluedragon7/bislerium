using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CommentsUseCases;

public class AddCommentUseCase : IAddCommentUseCase
{
    private readonly ICommentRepository _commentRepository;

    public AddCommentUseCase(ICommentRepository commentRepository)
    {
        this._commentRepository = commentRepository;
    }

    public void Execute(Comment comment)
    {
        _commentRepository.AddComment(comment);
    }
}