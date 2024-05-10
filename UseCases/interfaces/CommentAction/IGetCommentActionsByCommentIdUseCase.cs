using CoreBusiness;

namespace UseCases.CommentActionsUseCases;

public interface IGetCommentActionsByCommentIdUseCase
{
    IEnumerable<CommentAction> Execute(Guid commentId);
}