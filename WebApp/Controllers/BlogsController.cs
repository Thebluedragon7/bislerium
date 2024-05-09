using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UseCases.BlogImagesUseCases;
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
    private readonly IViewSelectedBlogUseCase _viewSelectedBlogUseCase;
    private readonly IDeleteBlogUseCase _deleteBlogUseCase;
    private readonly IEditBlogUseCase _editBlogUseCase;
    private readonly IGetCommentsByBlogIdUseCase _getCommentsByBlogIdUseCase;
    private readonly IGetBlogReactionsByBlogIdUseCase _getBlogReactionsByBlogIdUseCase;
    private readonly IAddBlogImagesUseCases _addBlogImagesUseCases;
    private readonly IGetBlogImagesUseCase _getBlogImagesUseCase;

    public BlogsController(
        UserManager<User> userManager,
        IAddBlogUseCase addBlogUseCase,
        IViewBlogsUseCase viewBlogsUseCase,
        IViewSelectedBlogUseCase viewSelectedBlogUseCase,
        IDeleteBlogUseCase deleteBlogUseCase,
        IEditBlogUseCase editBlogUseCase,
        IGetCommentsByBlogIdUseCase getCommentsByBlogIdUseCase,
        IGetBlogReactionsByBlogIdUseCase getBlogReactionsByBlogIdUseCase,
        IAddBlogImagesUseCases addBlogImagesUseCases,
        IGetBlogImagesUseCase getBlogImagesUseCase
    )
    {
        _userManager = userManager;
        _addBlogUseCase = addBlogUseCase;
        _viewBlogsUseCase = viewBlogsUseCase;
        _viewSelectedBlogUseCase = viewSelectedBlogUseCase;
        _deleteBlogUseCase = deleteBlogUseCase;
        _editBlogUseCase = editBlogUseCase;
        _getCommentsByBlogIdUseCase = getCommentsByBlogIdUseCase;
        _getBlogReactionsByBlogIdUseCase = getBlogReactionsByBlogIdUseCase;
        _addBlogImagesUseCases = addBlogImagesUseCases;
        _getBlogImagesUseCase = getBlogImagesUseCase;
    }

    public IActionResult Index(int pageNumber = 1, int pageSize = 2, string sortBy = "recency")
    {
        if (pageNumber < 1) pageNumber = 1;
        if (pageSize < 1) pageSize = 1;

        var blogs = _viewBlogsUseCase.Execute(pageNumber, pageSize, sortBy);
        return View(new BlogViewModel()
        {
            Blogs = blogs.ToList(),
            SortBy = sortBy,
            PageNumber = pageNumber,
            PageSize = pageSize
        });
    }

    [Authorize(Roles = "Blogger")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Blogger")]
    public async Task<IActionResult> Create(Blog blog, IEnumerable<IFormFile> images)
    {
        Console.WriteLine("Creating Blog");
        Console.WriteLine(images.ToList().Count);

        blog.Id = Guid.NewGuid();
        blog.AuthorId = _userManager.GetUserId(User)!;

        var blogImages = new List<BlogImage>();

        foreach (var image in images)
        {
            Console.WriteLine("Attemnpting to save images");
            if (image.Length > 3 * 1024 * 1024) // Skip if the image size is greater than 3 MB
            {
                continue;
            }

            string fileName = Path.GetFileNameWithoutExtension(image.FileName);
            string extension = Path.GetExtension(image.FileName);
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string uniqueFileName = $"{fileName}_{timeStamp}{extension}";

            var path = Path.Combine("wwwroot/images", uniqueFileName);

            string? directoryPath = Path.GetDirectoryName(path);
            if (directoryPath != null) Directory.CreateDirectory(directoryPath);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            var blogImage = new BlogImage
            {
                Id = Guid.NewGuid(),
                BlogId = blog.Id,
                ImageUrl = "/images/" + uniqueFileName
            };

            blogImages.Add(blogImage);
        }

        _addBlogUseCase.Execute(blog);
        _addBlogImagesUseCases.Execute(blog.Id, blogImages);
        return RedirectToAction("Index");
    }

    public IActionResult Details(Guid id)
    {
        var blog = _viewSelectedBlogUseCase.Execute(id);

        if (blog == null)
        {
            return NotFound();
        }

        blog.Comments = _getCommentsByBlogIdUseCase.Execute(id).ToList();
        blog.BlogReactions = _getBlogReactionsByBlogIdUseCase.Execute(id).ToList();
        blog.BlogImages = _getBlogImagesUseCase.Execute(id).ToList();
        return View(blog);
    }

    [Authorize(Roles = "Blogger")]
    public IActionResult Edit(Guid id)
    {
        var blog = _viewSelectedBlogUseCase.Execute(id);
        if (blog == null)
        {
            return NotFound();
        }

        blog.BlogImages = _getBlogImagesUseCase.Execute(id).ToList();

        return View(blog);
    }

    [HttpPost]
    [Authorize(Roles = "Blogger")]
    public async Task<IActionResult> Edit(Guid id, Blog blog, IEnumerable<IFormFile> images)
    {
        _editBlogUseCase.Execute(id, blog);

        var blogImages = new List<BlogImage>();

        foreach (var image in images)
        {
            Console.WriteLine("Attemnpting to save images");
            if (image.Length > 3 * 1024 * 1024) // Skip if the image size is greater than 3 MB
            {
                continue;
            }

            string fileName = Path.GetFileNameWithoutExtension(image.FileName);
            string extension = Path.GetExtension(image.FileName);
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string uniqueFileName = $"{fileName}_{timeStamp}{extension}";

            var path = Path.Combine("wwwroot/images", uniqueFileName);

            string? directoryPath = Path.GetDirectoryName(path);
            if (directoryPath != null) Directory.CreateDirectory(directoryPath);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            var blogImage = new BlogImage
            {
                Id = Guid.NewGuid(),
                BlogId = blog.Id,
                ImageUrl = "/images/" + uniqueFileName
            };

            blogImages.Add(blogImage);
        }

        _addBlogImagesUseCases.Execute(blog.Id, blogImages);

        return RedirectToAction("Edit", "Blogs", new { id });
    }

    [Authorize(Roles = "Blogger")]
    public IActionResult Delete(Guid id)
    {
        var blog = _viewSelectedBlogUseCase.Execute(id);
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