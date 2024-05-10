using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class NotificationSqlRepository : INotificationRepository
{
    private readonly BisleriumContext _db;

    public NotificationSqlRepository(BisleriumContext db)
    {
        _db = db;
    }

    public void AddNotification(Notification notification)
    {
        _db.Notifications.Add(notification);
        _db.SaveChanges();
    }

    public IEnumerable<Notification> GetNotificationsByUserId(string userId)
    {
        return _db.Notifications.Where(n => n.UserId == userId);
    }

    public void MarkNotificationAsSeen(Guid notificationId)
    {
        var notification = _db.Notifications.Find(notificationId);

        if (notification == null)
        {
            throw new Exception("Notification not found");
        }

        notification.IsSeen = true;
        _db.SaveChanges();
    }
}