using UseCases.DataStorePluginInterfaces;

namespace UseCases.NotificationsUseCases;

public class MarkNotificationAsSeenUseCase : IMarkNotificationAsSeenUseCase
{
    private readonly INotificationRepository _notificationRepository;

    public MarkNotificationAsSeenUseCase(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public void Execute(Guid notificationId)
    {
        _notificationRepository.MarkNotificationAsSeen(notificationId);
    }
}