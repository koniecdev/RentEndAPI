namespace Domain.Entities;

public class Pin
{
    [Key]
    public int Id { get; set; }
    public int CarId { get; set; }

    [ForeignKey("CarId")]
    public virtual Car Car { get; set; }
}