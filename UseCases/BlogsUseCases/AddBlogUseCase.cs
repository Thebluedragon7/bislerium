using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogsUseCases;

public class AddBlogUseCase
{
    private readonly IBlogRepository blogRepository;
    
    public AddBlogUseCase(IBlogRepository blogRepository)
    {
        this.blogRepository = blogRepository;
    }
    
    public void Execute(Blog blog)
    {
        blogRepository.AddBlog(blog);
    }
}