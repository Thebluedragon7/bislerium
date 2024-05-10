using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plugins.DataStore.SQL.constants;
using UseCases.BlogsUseCases;
using UseCases.CommentReactionsUseCases;
using UseCases.CommentsUseCases;
using UseCases.NotificationsUseCases;

namespace WebApp.Controllers;

public class CommentReactionsController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IAddCommentReactionUseCase _addCommentReactionUseCase;
    private readonly IDeleteCommentReactionUseCase _deleteCommentReactionUseCase;
    private readonly IGetCommentReactionsByCommentIdUseCase _getCommentReactionsByCommentIdUseCase;
    private readonly IGetCommentByIdUseCase _getCommentByIdUseCase;
    private readonly IViewSelectedBlogUseCase _viewSelectedBlogUseCase;
    private readonly IAddNotificationUseCase _addNotificationUseCase;

    public CommentReactionsController(
        UserManager<User> userManager,
        IAddCommentReactionUseCase addCommentReactionUseCase,
        IDeleteCommentReactionUseCase deleteCommentReactionUseCase,
        IGetCommentReactionsByCommentIdUseCase getCommentReactionsByCommentIdUseCase,
        IGetCommentByIdUseCase getCommentByIdUseCase,
        IViewSelectedBlogUseCase viewSelectedBlogUseCase,
        IAddNotificationUseCase addNotificationUseCase
    )
    {
        _userManager = userManager;
        _addCommentReactionUseCase = addCommentReactionUseCase;
        _deleteCommentReactionUseCase = deleteCommentReactionUseCase;
        _getCommentReactionsByCommentIdUseCase = getCommentReactionsByCommentIdUseCase;
        _getCommentByIdUseCase = getCommentByIdUseCase;
        _viewSelectedBlogUseCase = viewSelectedBlogUseCase;
        _addNotificationUseCase = addNotificationUseCase;
    }

    [HttpPost]
    [Authorize(Roles = "Blogger")]
    public IActionResult CreateUpvote(CommentReaction commentReaction)
    {
        commentReaction.Id = Guid.NewGuid();
        commentReaction.UserId = _userManager.GetUserId(User)!;
        commentReaction.ReactionTypeId = Guid.Parse(ReactionTypeMapper.UPVOTE);

        var comment = _getCommentByIdUseCase.Execute(commentReaction.CommentId);
        var blogId = comment!.BlogId;

        var existingCommentReaction = _getCommentReactionsByCommentIdUseCase.Execute(commentReaction.CommentId)
            .FirstOrDefault(cr => cr.UserId == commentReaction.UserId);

        var notification = new Notification()
        {
            Id = Guid.NewGuid(),
            UserId = comment.UserId,
            Message = $"{_userManager.GetUserName(User)} upvoted your comment",
            IsSeen = false
        };

        if (existingCommentReaction != null)
        {
            if (existingCommentReaction.ReactionTypeId == commentReaction.ReactionTypeId)
            {
                _deleteCommentReactionUseCase.Execute(existingCommentReaction.Id);
            }
            else
            {
                _deleteCommentReactionUseCase.Execute(existingCommentReaction.Id);
                _addCommentReactionUseCase.Execute(commentReaction);

                if (commentReaction.UserId != comment.UserId)
                {
                    _addNotificationUseCase.Execute(notification);
                }
            }
        }
        else
        {
            _addCommentReactionUseCase.Execute(commentReaction);
            if (commentReaction.UserId != comment!.UserId)
            {
                _addNotificationUseCase.Execute(notification);
            }
        }

        return RedirectToAction("Details", "Blogs", new { id = blogId });
    }

    [HttpPost]
    [Authorize(Roles = "Blogger")]
    public IActionResult CreateDownvote(CommentReaction commentReaction)
    {
        commentReaction.Id = Guid.NewGuid();
        commentReaction.UserId = _userManager.GetUserId(User)!;
        commentReaction.ReactionTypeId = Guid.Parse(ReactionTypeMapper.DOWNVOTE);

        var comment = _getCommentByIdUseCase.Execute(commentReaction.CommentId);
        var blogId = comment!.BlogId;

        var existingCommentReaction = _getCommentReactionsByCommentIdUseCase.Execute(commentReaction.CommentId)
            .FirstOrDefault(cr => cr.UserId == commentReaction.UserId);

        var notification = new Notification()
        {
            Id = Guid.NewGuid(),
            UserId = comment.UserId,
            Message = $"{_userManager.GetUserName(User)} downvoted your comment",
            IsSeen = false
        };

        if (existingCommentReaction != null)
        {
            if (existingCommentReaction.ReactionTypeId == commentReaction.ReactionTypeId)
            {
                _deleteCommentReactionUseCase.Execute(existingCommentReaction.Id);
            }
            else
            {
                _deleteCommentReactionUseCase.Execute(existingCommentReaction.Id);
                _addCommentReactionUseCase.Execute(commentReaction);

                if (commentReaction.UserId != comment.UserId)
                {
                    _addNotificationUseCase.Execute(notification);
                }
            }
        }
        else
        {
            _addCommentReactionUseCase.Execute(commentReaction);

            if (commentReaction.UserId != comment.UserId)
            {
                _addNotificationUseCase.Execute(notification);
            }
        }

        return RedirectToAction("Details", "Blogs", new { id = blogId });
    }
}