using CoreBusiness;

namespace UseCases.NotificationsUseCases;

public interface IGetNotificationsByUserIdUseCase
{
    IEnumerable<Notification> Execute(string userId);
}