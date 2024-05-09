using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogReactionsUseCases;

public class GetBlogReactionsByBlogIdUseCase : IGetBlogReactionsByBlogIdUseCase
{
    private readonly IBlogReactionRepository _blogReactionRepository;

    public GetBlogReactionsByBlogIdUseCase(IBlogReactionRepository blogReactionRepository)
    {
        this._blogReactionRepository = blogReactionRepository;
    }

    public IEnumerable<BlogReaction> Execute(Guid blogId)
    {
        return _blogReactionRepository.GetBlogReactionsByBlogId(blogId);
    }
}