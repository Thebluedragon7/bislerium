using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogsUseCases;

public class EditBlogUseCase
{
    private readonly IBlogRepository blogRepository;

    public EditBlogUseCase(IBlogRepository blogRepository)
    {
        this.blogRepository = blogRepository;
    }

    public void Execute(Guid blogId, Blog blog)
    {
        blogRepository.UpdateBlog(blogId, blog);
    }
}