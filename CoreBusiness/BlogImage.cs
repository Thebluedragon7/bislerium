using System.ComponentModel.DataAnnotations;

namespace CoreBusiness;

public class BlogImage
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string ImageUrl { get; set; } = String.Empty;
    [Required]
    [Display(Name = "Blog")]
    public Guid BlogId { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    // Navigation properties
    public Blog Blog { get; set; }
}