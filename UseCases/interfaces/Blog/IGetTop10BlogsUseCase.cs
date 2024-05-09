using CoreBusiness;

namespace UseCases.BlogsUseCases;

public interface IGetTop10BlogsUseCase
{
    IEnumerable<Blog> Execute(DateTime? month);
}