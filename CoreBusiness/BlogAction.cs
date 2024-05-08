using System.ComponentModel.DataAnnotations;

namespace CoreBusiness;

public class BlogAction
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    [Display(Name = "Blog")]
    public Guid BlogId { get; set; }
    [Required]
    public string Message { get; set; } = String.Empty;
    [Required]
    public DateTime ActionDate { get; set; } = DateTime.Now;
    
    // Navigation properties
    public Blog Blog { get; set; }
}