using CoreBusiness;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UseCases.NotificationsUseCases;

namespace WebApp.Controllers;

public class NotificationsController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IGetNotificationsByUserIdUseCase _getNotificationsByUserIdUseCase;
    private readonly IMarkNotificationAsSeenUseCase _markNotificationAsSeenUseCase;

    public NotificationsController(
        UserManager<User> userManager,
        IGetNotificationsByUserIdUseCase getNotificationsByUserIdUseCase,
        IMarkNotificationAsSeenUseCase markNotificationAsSeenUseCase
    )
    {
        _userManager = userManager;
        _getNotificationsByUserIdUseCase = getNotificationsByUserIdUseCase;
        _markNotificationAsSeenUseCase = markNotificationAsSeenUseCase;
    }

    [HttpGet]
    public IActionResult GetNotifications()
    {
        var userId = _userManager.GetUserId(User);
        var notifications = _getNotificationsByUserIdUseCase.Execute(userId!);
        return Json(notifications);
    }

    [HttpPost]
    public IActionResult MarkAsSeen(Guid id)
    {
        _markNotificationAsSeenUseCase.Execute(id);
        return Ok();
    }
}