using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogImagesUseCases;

public class GetBlogImagesUseCase : IGetBlogImagesUseCase
{
    private readonly IBlogImageRepository blogImageRepository;

    public GetBlogImagesUseCase(IBlogImageRepository blogImageRepository)
    {
        this.blogImageRepository = blogImageRepository;
    }
    
    public IEnumerable<BlogImage> Execute(Guid blogId)
    {
        return blogImageRepository.GetBlogImages(blogId);
    }
}