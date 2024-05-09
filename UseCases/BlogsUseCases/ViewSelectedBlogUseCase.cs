using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogsUseCases;

public class ViewSelectedBlogUseCase : IViewSelectedBlogUseCase
{
    private readonly IBlogRepository blogRepository;

    public ViewSelectedBlogUseCase(IBlogRepository blogRepository)
    {
        this.blogRepository = blogRepository;
    }

    public Blog Execute(Guid blogId)
    {
        return blogRepository.GetBlogById(blogId);
    }
}