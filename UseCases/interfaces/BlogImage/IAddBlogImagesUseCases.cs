using CoreBusiness;

namespace UseCases.BlogImagesUseCases;

public interface IAddBlogImagesUseCases
{
    void Execute(Guid blogId, List<BlogImage> blogImages);
}