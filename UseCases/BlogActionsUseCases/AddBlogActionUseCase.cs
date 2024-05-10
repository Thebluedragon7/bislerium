using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogActionsUseCases;

public class AddBlogActionUseCase : IAddBlogActionUseCase
{
    private readonly IBlogActionRepository _blogActionRepository;

    public AddBlogActionUseCase(IBlogActionRepository blogActionRepository)
    {
        _blogActionRepository = blogActionRepository;
    }

    public void Execute(BlogAction blogAction)
    {
        _blogActionRepository.AddBlogAction(blogAction);
    }
}