using UseCases.DataStorePluginInterfaces;

namespace UseCases.CommentsUseCases;

public class GetCommentCountByMonthUseCase : IGetCommentCountByMonthUseCase
{
    private readonly ICommentRepository _commentRepository;

    public GetCommentCountByMonthUseCase(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public int Execute(DateTime? month)
    {
        return _commentRepository.GetCommentCountByMonth(month);
    }
}