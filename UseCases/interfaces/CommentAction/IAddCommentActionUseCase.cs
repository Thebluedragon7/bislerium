using CoreBusiness;

namespace UseCases.CommentActionsUseCases;

public interface IAddCommentActionUseCase
{
    void Execute(CommentAction commentAction);
}