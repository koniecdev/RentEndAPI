namespace Domain.Entities;
public class Department
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(40)]
    public string City { get; set; } = "";
    [MaxLength(200)]
    public string FullAddress { get; set; } = "";
}