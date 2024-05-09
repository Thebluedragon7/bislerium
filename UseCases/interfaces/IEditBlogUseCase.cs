using CoreBusiness;

namespace UseCases.BlogsUseCases;

public interface IEditBlogUseCase
{
    void Execute(Guid blogId, Blog blog);
}