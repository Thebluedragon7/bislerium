using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogsUseCases;

public class GetTotalBlogsUseCase : IGetTotalBlogsUseCase
{
    private readonly IBlogRepository _blogRepository;

    public GetTotalBlogsUseCase(IBlogRepository blogRepository)
    {
        this._blogRepository = blogRepository;
    }

    public int Execute(DateTime? month)
    {
        return _blogRepository.GetTotalBlogs(month);
    }
}