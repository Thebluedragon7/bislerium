using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CommentsUseCases;

public class GetCommentByIdUseCase : IGetCommentByIdUseCase
{
    private readonly ICommentRepository _commentRepository;

    public GetCommentByIdUseCase(ICommentRepository commentRepository)
    {
        this._commentRepository = commentRepository;
    }

    public Comment? Execute(Guid commentId)
    {
        return _commentRepository.GetCommentById(commentId);
    }
}