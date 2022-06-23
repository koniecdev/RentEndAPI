using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dto;
public class PinDto
{
	public int Id { get; set; }
	public int CarId { get; set; }
	[ForeignKey("CarId")]
	public virtual CarDto Car{ get; set; }
}

