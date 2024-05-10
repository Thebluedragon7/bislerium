using System.ComponentModel.DataAnnotations;

namespace CoreBusiness;

public class CommentAction
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public Guid CommentId { get; set; }
    [Required]
    public string Message { get; set; } = string.Empty;
    [Required]
    public DateTime ActionDate { get; set; } = DateTime.Now;
    
    // Navigation properties
    public Comment Comment { get; set; }
    public User User { get; set; }
}
