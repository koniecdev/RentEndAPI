namespace Application.Dto;
public class CreateRentDto
{
	public string UserId { get; set; } = "";
	public int CarId { get; set; }
	public DateTime Since { get; set; }
	public DateTime Until { get; set; }
}

