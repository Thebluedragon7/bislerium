namespace UseCases.BlogImagesUseCases;

public interface IDeleteBlogImageUseCase
{
    void Execute(Guid blogId, Guid blogImageId);
}