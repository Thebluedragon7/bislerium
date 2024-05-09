using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogImagesUseCases;

public class DeleteBlogImageUseCase : IDeleteBlogImageUseCase
{
    private readonly IBlogImageRepository _blogImageRepository;

    public DeleteBlogImageUseCase(IBlogImageRepository blogImageRepository)
    {
        this._blogImageRepository = blogImageRepository;
    }

    public void Execute(Guid blogImageId)
    {
        _blogImageRepository.DeleteBlogImage(blogImageId);
    }
}