using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogActionsUseCases;

public class GetBlogActionsByBlogIdUseCase : IGetBlogActionsByBlogIdUseCase
{
    private readonly IBlogActionRepository _blogActionRepository;

    public GetBlogActionsByBlogIdUseCase(IBlogActionRepository blogActionRepository)
    {
        _blogActionRepository = blogActionRepository;
    }

    public IEnumerable<BlogAction> Execute(Guid blogId)
    {
        return _blogActionRepository.GetBlogActionsByBlogId(blogId);
    }
}