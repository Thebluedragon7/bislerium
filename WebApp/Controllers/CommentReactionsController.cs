using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plugins.DataStore.SQL.constants;
using UseCases.CommentReactionsUseCases;
using UseCases.CommentsUseCases;

namespace WebApp.Controllers;

public class CommentReactionsController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IAddCommentReactionUseCase _addCommentReactionUseCase;
    private readonly IDeleteCommentReactionUseCase _deleteCommentReactionUseCase;
    private readonly IGetCommentReactionsByCommentIdUseCase _getCommentReactionsByCommentIdUseCase;
    private readonly IGetCommentByIdUseCase _getCommentByIdUseCase;

    public CommentReactionsController(
        UserManager<User> userManager,
        IAddCommentReactionUseCase addCommentReactionUseCase,
        IDeleteCommentReactionUseCase deleteCommentReactionUseCase,
        IGetCommentReactionsByCommentIdUseCase getCommentReactionsByCommentIdUseCase,
        IGetCommentByIdUseCase getCommentByIdUseCase
    )
    {
        _userManager = userManager;
        _addCommentReactionUseCase = addCommentReactionUseCase;
        _deleteCommentReactionUseCase = deleteCommentReactionUseCase;
        _getCommentReactionsByCommentIdUseCase = getCommentReactionsByCommentIdUseCase;
        _getCommentByIdUseCase = getCommentByIdUseCase;
    }

    [HttpPost]
    [Authorize(Roles = "Blogger")]
    public IActionResult CreateUpvote(CommentReaction commentReaction)
    {
        commentReaction.Id = Guid.NewGuid();
        commentReaction.UserId = _userManager.GetUserId(User)!;
        commentReaction.ReactionTypeId = Guid.Parse(ReactionTypeMapper.UPVOTE);

        var existingCommentReaction = _getCommentReactionsByCommentIdUseCase.Execute(commentReaction.CommentId)
            .FirstOrDefault(cr => cr.UserId == commentReaction.UserId);

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
            }
        }
        else
        {
            _addCommentReactionUseCase.Execute(commentReaction);
        }

        var blogId = _getCommentByIdUseCase.Execute(commentReaction.CommentId)?.BlogId;

        if (blogId == null)
        {
            return NotFound();
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

        var existingCommentReaction = _getCommentReactionsByCommentIdUseCase.Execute(commentReaction.CommentId)
            .FirstOrDefault(cr => cr.UserId == commentReaction.UserId);

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
            }
        }
        else
        {
            _addCommentReactionUseCase.Execute(commentReaction);
        }

        var blogId = _getCommentByIdUseCase.Execute(commentReaction.CommentId)?.BlogId;

        if (blogId == null)
        {
            return NotFound();
        }

        return RedirectToAction("Details", "Blogs", new { id = blogId });
    }
}