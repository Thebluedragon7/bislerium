using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.BlogActionsUseCases;
using UseCases.BlogsUseCases;
using UseCases.CommentActionsUseCases;
using UseCases.CommentsUseCases;

namespace WebApp.Controllers;

[Authorize(Roles = "Admin")]
public class HistoryController : Controller
{
    private readonly IGetAllBlogsUseCase _getAllBlogsUseCase;
    private readonly IGetAllCommentsUseCase _getAllCommentsUseCase;
    private readonly IGetBlogActionsByBlogIdUseCase _getBlogActionsByBlogIdUseCase;
    private readonly IGetCommentActionsByCommentIdUseCase _getCommentActionsByCommentIdUseCase;

    public HistoryController(
        IGetAllBlogsUseCase getAllBlogsUseCase,
        IGetAllCommentsUseCase getAllCommentsUseCase,
        IGetBlogActionsByBlogIdUseCase getBlogActionsByBlogIdUseCase,
        IGetCommentActionsByCommentIdUseCase getCommentActionsByCommentIdUseCase
    )
    {
        _getAllBlogsUseCase = getAllBlogsUseCase;
        _getAllCommentsUseCase = getAllCommentsUseCase;
        _getBlogActionsByBlogIdUseCase = getBlogActionsByBlogIdUseCase;
        _getCommentActionsByCommentIdUseCase = getCommentActionsByCommentIdUseCase;
    }

    public IActionResult Blogs()
    {
        var blogs = _getAllBlogsUseCase.Execute();
        return View(blogs.ToList());
    }

    public IActionResult BlogActions(Guid id)
    {
        var blogActions = _getBlogActionsByBlogIdUseCase.Execute(id);
        return View(blogActions.ToList());
    }

    public IActionResult Comments()
    {
        var comments = _getAllCommentsUseCase.Execute();
        return View(comments.ToList());
    }

    public IActionResult CommentActions(Guid id)
    {
        var commentActions = _getCommentActionsByCommentIdUseCase.Execute(id);
        return View(commentActions.ToList());
    }
}