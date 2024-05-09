using CoreBusiness;

namespace UseCases.CommentReactionsUseCases;

public interface IAddCommentReactionUseCase
{
    void Execute(CommentReaction commentReaction);
}