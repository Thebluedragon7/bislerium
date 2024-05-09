using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogReactionsUseCases;

public class GetUpvotesByMonthUseCase : IGetUpvotesByMonthUseCase
{
    private readonly IBlogReactionRepository _blogReactionRepository;
    
    public GetUpvotesByMonthUseCase(IBlogReactionRepository blogReactionRepository)
    {
        _blogReactionRepository = blogReactionRepository;
    }
    
    public int Execute(DateTime? month)
    {
        return _blogReactionRepository.GetUpvotesByMonth(month);
    }
}