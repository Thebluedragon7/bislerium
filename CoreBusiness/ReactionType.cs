using System.ComponentModel.DataAnnotations;

namespace CoreBusiness;

public class ReactionType
{
    [Key]
    public Guid Id  { get; set; }
    [Required]
    public string Activity { get; set; } = String.Empty;
    [Required]
    public int Weightage { get; set; }
    
    // Navigation properties
    public List<BlogReaction>? BlogReactions { get; set; }
    public List<CommentReaction>? CommentReactions { get; set; }
}