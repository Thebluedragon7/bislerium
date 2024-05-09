using System.ComponentModel.DataAnnotations;

namespace CoreBusiness;

public class Notification
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    [Display(Name = "User")]
    public String UserId { get; set; } = String.Empty;
    [Required]
    public bool IsSeen { get; set; }
    [Required]
    public string Message { get; set; } = String.Empty;
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    // Navigation properties
    public User User { get; set; }
}