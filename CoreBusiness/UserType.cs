using System.ComponentModel.DataAnnotations;

namespace CoreBusiness;

public class UserType
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = String.Empty;
    
    // Navigation properties
    public List<User>? Users { get; set; }
}
