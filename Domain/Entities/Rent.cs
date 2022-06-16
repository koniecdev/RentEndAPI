using Domain.Common;
using Microsoft.AspNetCore.Identity;
namespace Domain.Entities;
public class Rent : AuditableEntity
{
    [Key]
    public int Id { get; set; }
    public string UserId { get; set; } = "";
    public int CarId { get; set; }

    public DateTime Since { get; set; }
    public DateTime Until { get; set; }
    [Required]
    [MaxLength(10)]
    public string Price { get; set; } = "";

    [ForeignKey("CarId")]
    public virtual Car Car { get; set; }

    [ForeignKey("UserId")]
    public virtual IdentityUser IdentityUser { get; set; }
}