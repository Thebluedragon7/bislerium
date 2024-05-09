using System.ComponentModel.DataAnnotations;

namespace CoreBusiness;

public class CommentReaction
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public Guid CommentId { get; set; }
    [Required]
    public String UserId { get; set; } = string.Empty;
    [Required]
    [Display(Name = "Reaction Type")]
    public Guid ReactionTypeId { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    // Navigation properties
    public Comment Comment { get; set; }
    public User User { get; set; }
    public ReactionType ReactionType { get; set; }
}