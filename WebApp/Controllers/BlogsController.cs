using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UseCases.BlogReactionsUseCases;
using UseCases.BlogsUseCases;
using UseCases.CommentsUseCases;
using WebApp.Models;

namespace WebApp.Controllers;

public class BlogsController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IAddBlogUseCase _addBlogUseCase;
    private readonly IViewBlogsUseCase _viewBlogsUseCase;
    private readonly IDeleteBlogUseCase _deleteBlogUseCase;
    private readonly IEditBlogUseCase _editBlogUseCase;
    private readonly IGetCommentsByBlogIdUseCase _getCommentsByBlogIdUseCase;
    private readonly IGetBlogReactionsByBlogIdUseCase _getBlogReactionsByBlogIdUseCase;


    public BlogsController(
        UserManager<User> userManager,
        IAddBlogUseCase addBlogUseCase,
        IViewBlogsUseCase viewBlogsUseCase,
        IDeleteBlogUseCase deleteBlogUseCase,
        IEditBlogUseCase editBlogUseCase,
        IGetCommentsByBlogIdUseCase getCommentsByBlogIdUseCase,
        IGetBlogReactionsByBlogIdUseCase getBlogReactionsByBlogIdUseCase
    )
    {
        _userManager = userManager;
        _addBlogUseCase = addBlogUseCase;
        _viewBlogsUseCase = viewBlogsUseCase;
        _deleteBlogUseCase = deleteBlogUseCase;
        _editBlogUseCase = editBlogUseCase;
        _getCommentsByBlogIdUseCase = getCommentsByBlogIdUseCase;
        _getBlogReactionsByBlogIdUseCase = getBlogReactionsByBlogIdUseCase;
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

        blog.Comments = _getCommentsByBlogIdUseCase.Execute(id).ToList();
        blog.BlogReactions = _getBlogReactionsByBlogIdUseCase.Execute(id).ToList();
        return View(blog);
    }

    [Authorize(Roles = "Blogger")]
    public IActionResult Edit(Guid id)
    {
        var blog = _viewBlogsUseCase.Execute().FirstOrDefault(b => b.Id == id);
        if (blog == null)
        {
            return NotFound();
        }

        return View(blog);
    }

    [HttpPost]
    [Authorize(Roles = "Blogger")]
    public IActionResult Edit(Guid id, Blog blog)
    {
        _editBlogUseCase.Execute(id, blog);
        return RedirectToAction("Index");
    }

    [Authorize(Roles = "Blogger")]
    public IActionResult Delete(Guid id)
    {
        var blog = _viewBlogsUseCase.Execute().FirstOrDefault(b => b.Id == id);
        if (blog == null)
        {
            return NotFound();
        }

        return View(blog);
    }

    [HttpPost]
    [Authorize(Roles = "Blogger")]
    public IActionResult DeleteBlog(Guid id)
    {
        _deleteBlogUseCase.Execute(id);
        return RedirectToAction("Index");
    }
}