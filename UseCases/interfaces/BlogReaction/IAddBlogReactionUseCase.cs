using CoreBusiness;

namespace UseCases.BlogReactionsUseCases;

public interface IAddBlogReactionUseCase
{
    void Execute(BlogReaction blogReaction);
}