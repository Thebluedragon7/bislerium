using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogsUseCases;

public class GetTop10BlogsUseCase : IGetTop10BlogsUseCase
{
    private readonly IBlogRepository _blogRepository;

    public GetTop10BlogsUseCase(IBlogRepository blogRepository)
    {
        this._blogRepository = blogRepository;
    }
    
    public IEnumerable<Blog> Execute(DateTime? month)
    {
        return _blogRepository.GetTop10Blogs(month);
    }
}