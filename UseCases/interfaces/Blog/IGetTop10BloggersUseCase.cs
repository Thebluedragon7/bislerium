using CoreBusiness;

namespace UseCases.BlogsUseCases;

public interface IGetTop10BloggersUseCase
{
    IEnumerable<BloggerInfo> Execute(DateTime? month);
}