namespace UseCases.BlogReactionsUseCases;

public interface IGetUpvotesByMonthUseCase
{
    int Execute(DateTime? month);
}