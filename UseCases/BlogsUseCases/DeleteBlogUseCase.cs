using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogsUseCases;

public class DeleteBlogUseCase : IDeleteBlogUseCase
{
    private readonly IBlogRepository blogRepository;
    
    public DeleteBlogUseCase(IBlogRepository blogRepository)
    {
        this.blogRepository = blogRepository;
    }
    
    public void Execute(Guid blogId)
    {
        blogRepository.DeleteBlog(blogId);
    }
}