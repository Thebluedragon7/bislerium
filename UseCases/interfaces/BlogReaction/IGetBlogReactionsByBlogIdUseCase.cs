using CoreBusiness;

namespace UseCases.BlogReactionsUseCases;

public interface IGetBlogReactionsByBlogIdUseCase
{
    IEnumerable<BlogReaction> Execute(Guid blogId);
}