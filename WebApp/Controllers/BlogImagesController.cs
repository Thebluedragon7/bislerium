using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.BlogImagesUseCases;

namespace WebApp.Controllers;

public class BlogImagesController : Controller
{
    private readonly IDeleteBlogImageUseCase _deleteBlogImageUseCase;
    private readonly IGetBlogImageUseCase _getBlogImageUseCase;

    public BlogImagesController(
        IDeleteBlogImageUseCase deleteBlogImageUseCase,
        IGetBlogImageUseCase getBlogImageUseCase
    )
    {
        _deleteBlogImageUseCase = deleteBlogImageUseCase;
        _getBlogImageUseCase = getBlogImageUseCase;
    }

    [HttpPost]
    [Authorize(Roles = "Blogger")]
    public IActionResult Delete(Guid blogImageId)
    {
        var blogId = _getBlogImageUseCase.Execute(blogImageId)?.BlogId;

        _deleteBlogImageUseCase.Execute(blogImageId);
        
        if (blogId == null)
        {
            return NotFound();
        }

        return RedirectToAction("Edit", "Blogs", new { id = blogId });
    }
}