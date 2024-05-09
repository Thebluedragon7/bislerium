using CoreBusiness;

namespace UseCases.BlogsUseCases;

public interface IAddBlogUseCase
{
    void Execute(Blog blog);
}