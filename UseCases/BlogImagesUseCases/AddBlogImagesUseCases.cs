using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogImagesUseCases;

public class AddBlogImagesUseCases : IAddBlogImagesUseCases
{
    private readonly IBlogImageRepository blogImageRepository;

    public AddBlogImagesUseCases(IBlogImageRepository blogImageRepository)
    {
        this.blogImageRepository = blogImageRepository;
    }

    public void Execute(Guid blogId, List<BlogImage> blogImages)
    {
        blogImageRepository.AddBlogImages(blogId, blogImages);
    }
}