using System.ComponentModel.DataAnnotations;

namespace CoreBusiness;

public class User
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    [Display(Name = "User Type")]
    public Guid UserTypeId { get; set; }
    [Required]
    public string FullName { get; set; } = String.Empty;
    [Required]
    public string Email { get; set; } = String.Empty;
    [Required]
    public string Password { get; set; } = String.Empty;
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    // Navigation properties
    public UserType UserType { get; set; }
    public List<CommentAction>? CommentActions { get; set; }
    public List<Comment>? Comments { get; set; }
    public List<Blog>? Blogs { get; set; }
    public List<Notification>? Notifications { get; set; }
    public List<CommentReaction>? CommentReactions { get; set; }
    public List<BlogReaction>? BlogReactions { get; set; }
}