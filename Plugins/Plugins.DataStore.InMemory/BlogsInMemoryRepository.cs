using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory;

public class BlogsInMemoryRepository : IBlogRepository
{
    private static List<Blog> _blogs = new List<Blog>()
    {
        new Blog()
        {
            Id = Guid.NewGuid(),
            Title = "Blog 1",
            Body = "Content 1",
            AuthorId = Guid.NewGuid(),
            UpdatedAt = DateTime.Now,
            CreatedAt = DateTime.Now,
        },
        new Blog()
        {
            Id = Guid.NewGuid(),
            Title = "Blog 2",
            Body = "Content 2",
            AuthorId = Guid.NewGuid(),
            UpdatedAt = DateTime.Now,
            CreatedAt = DateTime.Now
        },
        new Blog()
        {
            Id = Guid.NewGuid(),
            Title = "Blog 3",
            Body = "Content 3",
            AuthorId = Guid.NewGuid(),
            UpdatedAt = DateTime.Now,
            CreatedAt = DateTime.Now
        }
    };
    public void AddBlog(Blog blog)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Blog> GetBlogs()
    {
        throw new NotImplementedException();
    }

    public Blog? GetBlogById(Guid blogId)
    {
        throw new NotImplementedException();
    }

    public void UpdateBlog(Guid blogId, Blog blog)
    {
        throw new NotImplementedException();
    }

    public void DeleteBlog(Guid blogId)
    {
        throw new NotImplementedException();
    }
}