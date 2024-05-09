using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UseCases.CommentsUseCases;

namespace WebApp.Controllers;

public class CommentsController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IAddCommentUseCase _addCommentUseCase;
    private readonly IDeleteCommentUseCase _deleteCommentsUseCase;

    public CommentsController(
        UserManager<User> userManager,
        IAddCommentUseCase addCommentUseCase,
        IDeleteCommentUseCase deleteCommentsUseCase
    )
    {
        _userManager = userManager;
        _addCommentUseCase = addCommentUseCase;
        _deleteCommentsUseCase = deleteCommentsUseCase;
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

        return RedirectToAction("Details", "Blogs", new { id = comment.BlogId });
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