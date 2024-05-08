using CoreBusiness;

namespace UseCases.BlogsUseCases;

public interface IViewBlogsUseCase
{
    IEnumerable<Blog> Execute();
}