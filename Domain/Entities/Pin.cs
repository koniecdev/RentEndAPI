using Domain.Common;

namespace Domain.Entities;

public class Pin : AuditableEntity
{
    [Key]
    public int Id { get; set; }
    public int CarId { get; set; }

    [ForeignKey("CarId")]
    public virtual Car Car { get; set; }
}