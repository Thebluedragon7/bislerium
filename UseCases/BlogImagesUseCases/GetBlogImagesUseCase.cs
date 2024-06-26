using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogImagesUseCases;

public class GetBlogImagesUseCase : IGetBlogImagesUseCase
{
    private readonly IBlogImageRepository _blogImageRepository;

    public GetBlogImagesUseCase(IBlogImageRepository blogImageRepository)
    {
        this._blogImageRepository = blogImageRepository;
    }
    
    public IEnumerable<BlogImage> Execute(Guid blogId)
    {
        return _blogImageRepository.GetBlogImages(blogId);
    }
}