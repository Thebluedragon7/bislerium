using System.ComponentModel.DataAnnotations;

namespace CoreBusiness;

public class Comment
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    [Display(Name = "Blog")]
    public Guid BlogId { get; set; }
    [Required]
    [Display(Name = "User")]
    public String UserId { get; set; } = string.Empty;
    [Required]
    public string Text { get; set; } = string.Empty;
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime UpdatedAt { get; set; }
    
    // Navigation properties
    public Blog Blog { get; set; }
    public User User { get; set; }
    public List<CommentAction>? CommentActions { get; set; }
    public List<CommentReaction>? CommentReactions { get; set; }
}