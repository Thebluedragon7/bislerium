using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogsUseCases;

public class GetAllBlogsUseCase : IGetAllBlogsUseCase
{
    private readonly IBlogRepository _blogRepository;
    
    public GetAllBlogsUseCase(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }
    
    public IEnumerable<Blog> Execute()
    {
        return _blogRepository.GetAllBlogs();
    }
}