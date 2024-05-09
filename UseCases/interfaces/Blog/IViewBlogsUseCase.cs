using CoreBusiness;

namespace UseCases.BlogsUseCases;

public interface IViewBlogsUseCase
{
    IEnumerable<Blog> Execute(int pageNumber, int pageSize, string sortBy);
}