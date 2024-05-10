using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.NotificationsUseCases;

public class AddNotificationUseCase : IAddNotificationUseCase
{
    private readonly INotificationRepository _notificationRepository;

    public AddNotificationUseCase(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public void Execute(Notification notification)
    {
        _notificationRepository.AddNotification(notification);
    }
}