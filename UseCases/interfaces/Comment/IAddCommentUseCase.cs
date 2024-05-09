using CoreBusiness;

namespace UseCases.CommentsUseCases;

public interface IAddCommentUseCase
{
    void Execute(Comment comment);
}