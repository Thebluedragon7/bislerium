using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.BlogReactionsUseCases;
using UseCases.BlogsUseCases;
using UseCases.CommentsUseCases;
using WebApp.Models;

namespace WebApp.Controllers;

[Authorize(Roles = "Admin")]
public class DashboardController : Controller
{
    private readonly IGetTop10BlogsUseCase _getTop10BlogsUseCase;
    private readonly IGetTotalBlogsUseCase _getTotalBlogsUseCase;
    private readonly IGetCommentCountByMonthUseCase _getCommentCountByMonthUseCase;
    private readonly IGetUpvotesByMonthUseCase _getUpvotesByMonthUseCase;
    private readonly IGetDownvotesByMonthUseCase _getDownvotesByMonthUseCase;

    public DashboardController(
        IGetTop10BlogsUseCase getTop10BlogsUseCase,
        IGetTotalBlogsUseCase getTotalBlogsUseCase,
        IGetCommentCountByMonthUseCase getCommentCountByMonthUseCase,
        IGetUpvotesByMonthUseCase getUpvotesByMonthUseCase,
        IGetDownvotesByMonthUseCase getDownvotesByMonthUseCase
    )
    {
        _getTop10BlogsUseCase = getTop10BlogsUseCase;
        _getTotalBlogsUseCase = getTotalBlogsUseCase;
        _getCommentCountByMonthUseCase = getCommentCountByMonthUseCase;
        _getUpvotesByMonthUseCase = getUpvotesByMonthUseCase;
        _getDownvotesByMonthUseCase = getDownvotesByMonthUseCase;
    }

    public IActionResult Index(DateTime? month)
    {
        var totalBlogs = _getTotalBlogsUseCase.Execute(month);
        var topBlogs = _getTop10BlogsUseCase.Execute(month);
        var totalComments = _getCommentCountByMonthUseCase.Execute(month);
        var totalUpvotes = _getUpvotesByMonthUseCase.Execute(month);
        var totalDownvotes = _getDownvotesByMonthUseCase.Execute(month);

        return View(new DashboardViewModel()
        {
            TotalBlogs = totalBlogs,
            TotalComments = totalComments,
            TotalUpvotes = totalUpvotes,
            TotalDownvotes = totalDownvotes,
            TopBloggers = new List<User>(),
            TopBlogs = topBlogs.ToList()
        });
    }
}