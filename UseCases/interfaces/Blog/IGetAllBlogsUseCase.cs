using CoreBusiness;

namespace UseCases.BlogsUseCases;

public interface IGetAllBlogsUseCase
{
    IEnumerable<Blog> Execute();
}