using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UseCases.BlogsUseCases;
using UseCases.CommentActionsUseCases;
using UseCases.CommentsUseCases;
using UseCases.NotificationsUseCases;

namespace WebApp.Controllers;

public class CommentsController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IAddCommentUseCase _addCommentUseCase;
    private readonly IDeleteCommentUseCase _deleteCommentsUseCase;
    private readonly IViewSelectedBlogUseCase _viewSelectedBlogUseCase;
    private readonly IAddNotificationUseCase _addNotificationUseCase;
    private readonly IAddCommentActionUseCase _addCommentActionUseCase;
    private readonly IUpdateCommentUseCase _editCommentUseCase;
    private readonly IGetCommentByIdUseCase _getCommentByIdUseCase;

    public CommentsController(
        UserManager<User> userManager,
        IAddCommentUseCase addCommentUseCase,
        IDeleteCommentUseCase deleteCommentsUseCase,
        IViewSelectedBlogUseCase viewSelectedBlogUseCase,
        IAddNotificationUseCase addNotificationUseCase,
        IAddCommentActionUseCase addCommentActionUseCase,
        IUpdateCommentUseCase editCommentUseCase,
        IGetCommentByIdUseCase getCommentByIdUseCase
    )
    {
        _userManager = userManager;
        _addCommentUseCase = addCommentUseCase;
        _deleteCommentsUseCase = deleteCommentsUseCase;
        _viewSelectedBlogUseCase = viewSelectedBlogUseCase;
        _addNotificationUseCase = addNotificationUseCase;
        _addCommentActionUseCase = addCommentActionUseCase;
        _editCommentUseCase = editCommentUseCase;
        _getCommentByIdUseCase = getCommentByIdUseCase;
    }

    [Authorize(Roles = "Blogger")]
    public IActionResult Create(Guid blogId)
    {
        ViewBag.BlogId = blogId;
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Blogger")]
    public IActionResult Create(Comment comment)
    {
        comment.Id = Guid.NewGuid();
        comment.UserId = _userManager.GetUserId(User)!;

        _addCommentUseCase.Execute(comment);


        var blogAuthorId = _viewSelectedBlogUseCase.Execute(comment.BlogId)!.AuthorId;

        if (comment.UserId != blogAuthorId)
        {
            var notification = new Notification()
            {
                Id = Guid.NewGuid(),
                UserId = blogAuthorId,
                Message = $"{_userManager.GetUserName(User)} commented on your blog",
                IsSeen = false
            };

            _addNotificationUseCase.Execute(notification);
        }

        var commentAction = new CommentAction()
        {
            Id = Guid.NewGuid(),
            CommentId = comment.Id,
            Message = $"{_userManager.GetUserName(User)} Commented"
        };

        _addCommentActionUseCase.Execute(commentAction);

        return RedirectToAction("Details", "Blogs", new { id = comment.BlogId });
    }

    [Authorize(Roles = "Blogger")]
    public IActionResult Edit(Guid id)
    {
        var comment = _getCommentByIdUseCase.Execute(id);
        if (comment == null)
        {
            return NotFound();
        }

        return View(comment);
    }

    [HttpPost]
    [Authorize(Roles = "Blogger")]
    public IActionResult Edit(Guid id, Comment comment)
    {
        _editCommentUseCase.Execute(id, comment);

        var existingComment = _getCommentByIdUseCase.Execute(id);

        var commentAction = new CommentAction()
        {
            Id = Guid.NewGuid(),
            CommentId = comment.Id,
            Message = $"{_userManager.GetUserName(User)} edit comment"
        };

        _addCommentActionUseCase.Execute(commentAction);

        return RedirectToAction("Details", "Blogs", new { id = existingComment!.BlogId });
    }


    [Authorize(Roles = "Blogger")]
    public IActionResult Delete(Guid id)
    {
        ViewBag.CommentId = id;
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Blogger")]
    public IActionResult DeleteComment(Guid id)
    {
        _deleteCommentsUseCase.Execute(id);
        return RedirectToAction("Index", "Blogs");
    }
}