using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.BlogsUseCases;

public class EditBlogUseCase : IEditBlogUseCase
{
    private readonly IBlogRepository _blogRepository;

    public EditBlogUseCase(IBlogRepository blogRepository)
    {
        this._blogRepository = blogRepository;
    }

    public void Execute(Guid blogId, Blog blog)
    {
        _blogRepository.UpdateBlog(blogId, blog);
    }
}