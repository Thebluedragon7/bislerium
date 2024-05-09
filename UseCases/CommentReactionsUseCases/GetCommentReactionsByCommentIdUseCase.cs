using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CommentReactionsUseCases;

public class GetCommentReactionsByCommentIdUseCase : IGetCommentReactionsByCommentIdUseCase
{
    private readonly ICommentReactionRepository _commentReactionRepository;

    public GetCommentReactionsByCommentIdUseCase(ICommentReactionRepository commentReactionRepository)
    {
        this._commentReactionRepository = commentReactionRepository;
    }
    
    public IEnumerable<CommentReaction> Execute(Guid commentId)
    {
        return _commentReactionRepository.GetCommentReactionsByCommentId(commentId);
    }
}