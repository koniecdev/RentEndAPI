using Domain.Common;

namespace Domain.Entities;
public class Department : AuditableEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(40)]
    public string City { get; set; } = "";
    [MaxLength(200)]
    public string FullAddress { get; set; } = "";
}