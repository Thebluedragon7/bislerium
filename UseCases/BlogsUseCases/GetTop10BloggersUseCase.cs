using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogsUseCases;

public class GetTop10BloggersUseCase : IGetTop10BloggersUseCase
{
    private readonly IBlogRepository _blogRepository;

    public GetTop10BloggersUseCase(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public IEnumerable<BloggerInfo> Execute(DateTime? month)
    {
        return _blogRepository.GetTop10Bloggers(month);
    }
}