using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CommentActionsUseCases;

public class GetCommentActionsByCommentIdUseCase : IGetCommentActionsByCommentIdUseCase
{
    private readonly ICommentActionRepository _commentActionRepository;

    public GetCommentActionsByCommentIdUseCase(ICommentActionRepository commentActionRepository)
    {
        _commentActionRepository = commentActionRepository;
    }

    public IEnumerable<CommentAction> Execute(Guid commentId)
    {
        return _commentActionRepository.GetCommentActionsByCommentId(commentId);
    }
}