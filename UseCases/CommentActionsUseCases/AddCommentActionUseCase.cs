using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CommentActionsUseCases;

public class AddCommentActionUseCase : IAddCommentActionUseCase
{
    private readonly ICommentActionRepository _commentActionRepository;

    public AddCommentActionUseCase(ICommentActionRepository commentActionRepository)
    {
        _commentActionRepository = commentActionRepository;
    }

    public void Execute(CommentAction commentAction)
    {
        _commentActionRepository.AddCommentAction(commentAction);
    }
}