using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CommentsUseCases;

public class GetAllCommentsUseCase : IGetAllCommentsUseCase
{
    private readonly ICommentRepository _commentRepository;

    public GetAllCommentsUseCase(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public IEnumerable<Comment> Execute()
    {
        return _commentRepository.GetAllComments();
    }
}