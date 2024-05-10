using CoreBusiness;

namespace UseCases.BlogActionsUseCases;

public interface IGetBlogActionsByBlogIdUseCase
{
    IEnumerable<BlogAction> Execute(Guid blogId);
}