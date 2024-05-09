using CoreBusiness;

namespace UseCases.BlogImagesUseCases;

public interface IGetBlogImagesUseCase
{
    IEnumerable<BlogImage> Execute(Guid blogId);
}