using CoreBusiness;

namespace WebApp.Models;

public class DashboardViewModel
{
    public int TotalBlogs { get; set; }
    public int TotalComments { get; set; }
    public int TotalUpvotes { get; set; }
    public int TotalDownvotes { get; set; }

    public List<BloggerInfo> TopBloggers { get; set; }
    public List<Blog> TopBlogs { get; set; }
}