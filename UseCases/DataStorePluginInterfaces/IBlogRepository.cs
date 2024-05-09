using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces;

public interface IBlogRepository
{
    void AddBlog(Blog blog);
    IEnumerable<Blog> GetBlogs(int pageNumber, int pageSize, String sortBy);
    Blog? GetBlogById(Guid blogId);
    void UpdateBlog(Guid blogId, Blog blog);
    void DeleteBlog(Guid blogId);
    IEnumerable<Blog> GetTop10Blogs(DateTime? month);
    int GetTotalBlogs(DateTime? month);
    public IEnumerable<BloggerInfo> GetTop10Bloggers(DateTime? month);
}