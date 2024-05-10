using CoreBusiness;

namespace UseCases.CommentsUseCases;

public interface IUpdateCommentUseCase
{
    void Execute(Guid commentId, Comment comment);
}