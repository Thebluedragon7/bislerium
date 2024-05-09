using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogsUseCases;

public class AddBlogUseCase : IAddBlogUseCase
{
    private readonly IBlogRepository _blogRepository;
    
    public AddBlogUseCase(IBlogRepository blogRepository)
    {
        this._blogRepository = blogRepository;
    }
    
    public void Execute(Blog blog)
    {
        _blogRepository.AddBlog(blog);
    }
}