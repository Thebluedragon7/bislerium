using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogReactionsUseCases;

public class GetDownvotesByMonthUseCase : IGetDownvotesByMonthUseCase
{
    private readonly IBlogReactionRepository _blogReactionRepository;

    public GetDownvotesByMonthUseCase(IBlogReactionRepository blogReactionRepository)
    {
        _blogReactionRepository = blogReactionRepository;
    }
    
    public int Execute(DateTime? month)
    {
        return _blogReactionRepository.GetDownvotesByMonth(month);
    }
}