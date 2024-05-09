using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CoreBusiness;

public class User : IdentityUser
{
    [Required]
    public string FullName { get; set; } = String.Empty;
    
    // Navigation properties
    // public UserType UserType { get; set; }
    public List<CommentAction>? CommentActions { get; set; }
    public List<Comment>? Comments { get; set; }
    public List<Blog>? Blogs { get; set; }
    public List<Notification>? Notifications { get; set; }
    public List<CommentReaction>? CommentReactions { get; set; }
    public List<BlogReaction>? BlogReactions { get; set; }
}