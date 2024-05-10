using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UseCases.BlogReactionsUseCases;
using UseCases.BlogsUseCases;
using UseCases.NotificationsUseCases;
using UseCases.ReactionTypeUseCases;

namespace WebApp.Controllers;

public class BlogReactionsController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IAddBlogReactionUseCase _addBlogReactionUseCase;
    private readonly IDeleteBlogReactionUseCase _deleteBlogReactionUseCase;
    private readonly IGetReactionTypeByActivityNameUseCase _getReactionTypeByActivityNameUseCase;
    private readonly IGetBlogReactionsByBlogIdUseCase _getBlogReactionsByBlogIdUseCase;
    private readonly IViewSelectedBlogUseCase _viewSelectedBlogUseCase;
    private readonly IAddNotificationUseCase _addNotificationUseCase;

    public BlogReactionsController(
        UserManager<User> userManager,
        IAddBlogReactionUseCase addBlogReactionUseCase,
        IDeleteBlogReactionUseCase deleteBlogReactionUseCase,
        IGetReactionTypeByActivityNameUseCase getReactionTypeByActivityNameUseCase,
        IGetBlogReactionsByBlogIdUseCase getBlogReactionsByBlogIdUseCase,
        IViewSelectedBlogUseCase viewSelectedBlogUseCase,
        IAddNotificationUseCase addNotificationUseCase
    )
    {
        _userManager = userManager;
        _addBlogReactionUseCase = addBlogReactionUseCase;
        _deleteBlogReactionUseCase = deleteBlogReactionUseCase;
        _getReactionTypeByActivityNameUseCase = getReactionTypeByActivityNameUseCase;
        _getBlogReactionsByBlogIdUseCase = getBlogReactionsByBlogIdUseCase;
        _viewSelectedBlogUseCase = viewSelectedBlogUseCase;
        _addNotificationUseCase = addNotificationUseCase;
    }

    [HttpPost]
    [Authorize(Roles = "Blogger")]
    public IActionResult CreateUpvote(BlogReaction blogReaction)
    {
        blogReaction.Id = Guid.NewGuid();
        blogReaction.UserId = _userManager.GetUserId(User)!;
        var upvoteReactionTypeId = _getReactionTypeByActivityNameUseCase.Execute("Upvote")!.Id;
        blogReaction.ReactionTypeId = upvoteReactionTypeId;

        var existingBlogReaction = _getBlogReactionsByBlogIdUseCase.Execute(blogReaction.BlogId)
            .FirstOrDefault(br => br.UserId == blogReaction.UserId);

        var blog = _viewSelectedBlogUseCase.Execute(blogReaction.BlogId);

        var notification = new Notification
        {
            Id = Guid.NewGuid(),
            UserId = blog!.AuthorId,
            Message = $"{_userManager.GetUserName(User)} upvoted your blog {blog.Title}",
            IsSeen = false
        };

        if (existingBlogReaction != null)
        {
            if (existingBlogReaction.ReactionTypeId == blogReaction.ReactionTypeId)
            {
                _deleteBlogReactionUseCase.Execute(existingBlogReaction.Id);
            }
            else
            {
                _deleteBlogReactionUseCase.Execute(existingBlogReaction.Id);
                _addBlogReactionUseCase.Execute(blogReaction);

                if (blogReaction.UserId != blog.AuthorId)
                {
                    _addNotificationUseCase.Execute(notification);
                }
            }
        }
        else
        {
            _addBlogReactionUseCase.Execute(blogReaction);

            if (blogReaction.UserId != blog.AuthorId)
            {
                _addNotificationUseCase.Execute(notification);
            }
        }

        return RedirectToAction("Details", "Blogs", new { id = blogReaction.BlogId });
    }

    [HttpPost]
    [Authorize(Roles = "Blogger")]
    public IActionResult CreateDownvote(BlogReaction blogReaction)
    {
        blogReaction.Id = Guid.NewGuid();
        blogReaction.UserId = _userManager.GetUserId(User)!;
        var downvoteReactionTypeId = _getReactionTypeByActivityNameUseCase.Execute("Downvote")!.Id;
        blogReaction.ReactionTypeId = downvoteReactionTypeId;

        var existingBlogReaction = _getBlogReactionsByBlogIdUseCase.Execute(blogReaction.BlogId)
            .FirstOrDefault(br => br.UserId == blogReaction.UserId);

        var blog = _viewSelectedBlogUseCase.Execute(blogReaction.BlogId);

        var notification = new Notification
        {
            Id = Guid.NewGuid(),
            UserId = blog!.AuthorId,
            Message = $"{_userManager.GetUserName(User)} downvoted your blog {blog.Title}",
            IsSeen = false
        };

        if (existingBlogReaction != null)
        {
            if (existingBlogReaction.ReactionTypeId == blogReaction.ReactionTypeId)
            {
                _deleteBlogReactionUseCase.Execute(existingBlogReaction.Id);
            }
            else
            {
                _deleteBlogReactionUseCase.Execute(existingBlogReaction.Id);
                _addBlogReactionUseCase.Execute(blogReaction);

                if (blogReaction.UserId != blog.AuthorId)
                {
                    _addNotificationUseCase.Execute(notification);
                }
            }
        }
        else
        {
            _addBlogReactionUseCase.Execute(blogReaction);
            if (blogReaction.UserId != blog.AuthorId)
            {
                _addNotificationUseCase.Execute(notification);
            }
        }

        return RedirectToAction("Details", "Blogs", new { id = blogReaction.BlogId });
    }
}