using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogsUseCases;

public class ViewSelectedBlogUseCase : IViewSelectedBlogUseCase
{
    private readonly IBlogRepository _blogRepository;

    public ViewSelectedBlogUseCase(IBlogRepository blogRepository)
    {
        this._blogRepository = blogRepository;
    }

    public Blog? Execute(Guid blogId)
    {
        return _blogRepository.GetBlogById(blogId);
    }
}