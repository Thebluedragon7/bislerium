using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UseCases.BlogsUseCases;
using WebApp.Models;

namespace WebApp.Controllers;

public class BlogsController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IAddBlogUseCase _addBlogUseCase;
    private readonly IViewBlogsUseCase _viewBlogsUseCase;

    public BlogsController(
        UserManager<User> userManager,
        IAddBlogUseCase addBlogUseCase,
        IViewBlogsUseCase viewBlogsUseCase
    )
    {
        _userManager = userManager;
        _addBlogUseCase = addBlogUseCase;
        _viewBlogsUseCase = viewBlogsUseCase;
    }

    public IActionResult Index()
    {
        var blogs = _viewBlogsUseCase.Execute();
        return View(new BlogViewModel()
        {
            Blogs = blogs.ToList()
        });
    }

    [Authorize(Roles = "Blogger")]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [Authorize(Roles = "Blogger")]
    public IActionResult Create(Blog blog)
    {
        blog.Id = Guid.NewGuid();
        blog.AuthorId = _userManager.GetUserId(User)!;
        
        _addBlogUseCase.Execute(blog);
        return RedirectToAction("Index");
    }
    
    public IActionResult Details(Guid id)
    {
        var blog = _viewBlogsUseCase.Execute().FirstOrDefault(b => b.Id == id);
        if (blog == null)
        {
            return NotFound();
        }
        return View(blog);
    }
}