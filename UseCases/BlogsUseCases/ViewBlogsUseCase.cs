using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogsUseCases;

public class ViewBlogsUseCase : IViewBlogsUseCase
{
    private readonly IBlogRepository blogRepository;

    public ViewBlogsUseCase(IBlogRepository blogRepository)
    {
        this.blogRepository = blogRepository;
    }

    public IEnumerable<Blog> Execute(int pageNumber, int pageSize, string sortBy)
    {
        return this.blogRepository.GetBlogs(pageNumber, pageSize, sortBy);
    }
}