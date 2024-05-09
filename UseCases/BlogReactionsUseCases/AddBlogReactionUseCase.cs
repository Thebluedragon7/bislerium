using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogReactionsUseCases;

public class AddBlogReactionUseCase : IAddBlogReactionUseCase
{
    private readonly IBlogReactionRepository _blogReactionRepository;

    public AddBlogReactionUseCase(IBlogReactionRepository blogReactionRepository)
    {
        this._blogReactionRepository = blogReactionRepository;
    }
    
    public void Execute(BlogReaction blogReaction)
    {
        _blogReactionRepository.AddBlogReaction(blogReaction);
    }

}