using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.NotificationsUseCases;

public class GetNotificationsByUserIdUseCase : IGetNotificationsByUserIdUseCase
{
    private readonly INotificationRepository _notificationRepository;

    public GetNotificationsByUserIdUseCase(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public IEnumerable<Notification> Execute(string userId)
    {
        return _notificationRepository.GetNotificationsByUserId(userId);
    }
}