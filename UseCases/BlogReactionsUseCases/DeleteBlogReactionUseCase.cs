using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogReactionsUseCases;

public class DeleteBlogReactionUseCase : IDeleteBlogReactionUseCase
{
    private readonly IBlogReactionRepository _blogReactionRepository;

    public DeleteBlogReactionUseCase(IBlogReactionRepository blogReactionRepository)
    {
        this._blogReactionRepository = blogReactionRepository;
    }

    public void Execute(Guid blogReactionId)
    {
        _blogReactionRepository.DeleteBlogReaction(blogReactionId);
    }
}