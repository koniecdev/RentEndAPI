using Domain.Common;
namespace Domain.Entities;

public class Brand : AuditableEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = "";

	public Brand(){}
	public Brand(int id, string name)
	{
		(Id, Name) = (id, name);
	}
}
