using CoreBusiness;

namespace UseCases.CommentReactionsUseCases;

public interface IGetCommentReactionsByCommentIdUseCase
{
    IEnumerable<CommentReaction> Execute(Guid commentId);
}