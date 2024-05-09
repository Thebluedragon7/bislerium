using CoreBusiness;

namespace WebApp.Models;

public class BlogViewModel
{
    public List<Blog> Blogs { get; set; } = new();
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SortBy { get; set; }
}