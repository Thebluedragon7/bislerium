using System.ComponentModel.DataAnnotations;

namespace CoreBusiness;

public class BlogReaction
{
    public Guid BlogId { get; set; }
    public Guid UserId { get; set; }
    [Required]
    [Display(Name = "Reaction Type")]
    public Guid ReactionTypeId { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    // Navigation properties
    public Blog Blog { get; set; }
    public User User { get; set; }
    public ReactionType ReactionType { get; set; }
}