namespace UseCases.BlogReactionsUseCases;

public interface IDeleteBlogReactionUseCase
{
    void Execute(Guid blogReactionId);
}