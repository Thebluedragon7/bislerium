using CoreBusiness;

namespace UseCases.CommentsUseCases;

public interface IGetCommentsByBlogIdUseCase
{
    IEnumerable<Comment> Execute(Guid blogId);
}