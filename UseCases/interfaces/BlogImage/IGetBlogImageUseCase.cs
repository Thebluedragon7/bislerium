using CoreBusiness;

namespace UseCases.BlogImagesUseCases;

public interface IGetBlogImageUseCase
{
    BlogImage? Execute(Guid blogImageId);
}