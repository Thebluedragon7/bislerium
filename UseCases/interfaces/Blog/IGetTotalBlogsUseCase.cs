namespace UseCases.BlogsUseCases;

public interface IGetTotalBlogsUseCase
{
    int Execute(DateTime? month);
}