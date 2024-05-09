namespace UseCases.CommentsUseCases;

public interface IGetCommentCountByMonthUseCase
{
    int Execute(DateTime? month);
}