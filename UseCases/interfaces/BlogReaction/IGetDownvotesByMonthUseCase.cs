namespace UseCases.BlogReactionsUseCases;

public interface IGetDownvotesByMonthUseCase
{
    int Execute(DateTime? month);
}