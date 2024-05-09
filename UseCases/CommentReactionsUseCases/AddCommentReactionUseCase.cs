using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CommentReactionsUseCases;

public class AddCommentReactionUseCase : IAddCommentReactionUseCase
{
    private readonly ICommentReactionRepository _commentReactionRepository;

    public AddCommentReactionUseCase(ICommentReactionRepository commentReactionRepository)
    {
        this._commentReactionRepository = commentReactionRepository;
    }

    public void Execute(CommentReaction commentReaction)
    {
        _commentReactionRepository.AddCommentReaction(commentReaction);
    }
}