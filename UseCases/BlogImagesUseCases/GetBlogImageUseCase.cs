using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogImagesUseCases;

public class GetBlogImageUseCase : IGetBlogImageUseCase
{
    private readonly IBlogImageRepository _blogImageRepository;

    public GetBlogImageUseCase(IBlogImageRepository blogImageRepository)
    {
        this._blogImageRepository = blogImageRepository;
    }

    public BlogImage? Execute(Guid blogImageId)
    {
        return _blogImageRepository.GetBlogImage(blogImageId);
    }
}