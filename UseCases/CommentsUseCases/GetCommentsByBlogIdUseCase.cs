using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CommentsUseCases;

public class GetCommentsByBlogIdUseCase : IGetCommentsByBlogIdUseCase
{
    private readonly ICommentRepository _commentRepository;

    public GetCommentsByBlogIdUseCase(ICommentRepository commentRepository)
    {
        this._commentRepository = commentRepository;
    }

    public IEnumerable<Comment> Execute(Guid blogId)
    {
        return _commentRepository.GetCommentsByBlogId(blogId);
    }
}