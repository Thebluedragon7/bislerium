using CoreBusiness;

namespace UseCases.CommentsUseCases;

public interface IGetAllCommentsUseCase
{
    IEnumerable<Comment> Execute();
}