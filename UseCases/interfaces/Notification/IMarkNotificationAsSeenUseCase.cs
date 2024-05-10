namespace UseCases.NotificationsUseCases;

public interface IMarkNotificationAsSeenUseCase
{
    void Execute(Guid notificationId);
}