namespace Application.Dto;
public class RentDto
{
	public int Id { get; set; }
	public string UserId { get; set; } = "";
	public int CarId { get; set; }
	public DateTime Since { get; set; }
	public DateTime Until { get; set; }
	public string Price { get; set; } = "";
}

