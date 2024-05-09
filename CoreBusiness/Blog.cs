using System.ComponentModel.DataAnnotations;

namespace CoreBusiness;

public class Blog
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; } = String.Empty;
    [Required]
    public string Body { get; set; } = String.Empty;
    [Required]
    public string Subtitle { get; set; } = String.Empty;
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    [Required]
    [Display(Name = "Author")]
    public String AuthorId { get; set; } = String.Empty;
    
    // Navigation properties
    public User Author { get; set; }
    public List<BlogImage>? BlogImages { get; set; }
    public List<Comment>? Comments { get; set; }
    public List<BlogAction>? BlogActions { get; set; }
    public List<BlogReaction>? BlogReactions { get; set; }
}