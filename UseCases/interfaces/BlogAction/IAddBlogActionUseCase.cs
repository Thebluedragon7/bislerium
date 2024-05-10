using CoreBusiness;

namespace UseCases.BlogActionsUseCases;

public interface IAddBlogActionUseCase
{
    void Execute(BlogAction blogAction);
}