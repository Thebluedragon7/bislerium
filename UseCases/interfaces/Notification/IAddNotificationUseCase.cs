using CoreBusiness;

namespace UseCases.NotificationsUseCases;

public interface IAddNotificationUseCase
{
    void Execute(Notification notification);
}