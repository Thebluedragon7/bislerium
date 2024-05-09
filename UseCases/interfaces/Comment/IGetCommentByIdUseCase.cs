using CoreBusiness;

namespace UseCases.CommentsUseCases;

public interface IGetCommentByIdUseCase
{
    Comment? Execute(Guid commentId);
}