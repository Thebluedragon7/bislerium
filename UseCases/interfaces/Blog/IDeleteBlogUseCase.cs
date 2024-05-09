namespace UseCases.BlogsUseCases;

public interface IDeleteBlogUseCase
{
    void Execute(Guid blogId);
}