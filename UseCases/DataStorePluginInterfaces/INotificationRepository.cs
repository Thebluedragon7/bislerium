using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface INotificationRepository
{
    void AddNotification(Notification notification);
    IEnumerable<Notification> GetNotificationsByUserId(string userId);
    void MarkNotificationAsSeen(Guid notificationId);
}