using Microsoft.AspNetCore.Mvc;
using UseCases.BlogsUseCases;

namespace WebApp.Controllers;

public class BlogsController : Controller
{
    private readonly IViewBlogsUseCase _viewBlogsUseCase;

    public BlogsController(IViewBlogsUseCase viewBlogsUseCase )
    {
        _viewBlogsUseCase = viewBlogsUseCase;
    }
    // GET
    public IActionResult Index()
    {
        var blogs = _viewBlogsUseCase.Execute();
        return View();
    }
}