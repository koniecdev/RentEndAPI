using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dto;
public class CarDto
{
	public int Id { get; set; }
    public int YearOfProduction { get; set; }
    public string Engine { get; set; } = "";
    public int Horsepower { get; set; }
    public int Drive { get; set; }
    public int Transmission { get; set; }
	public string Model { get; set; } = "";
    public int KmPerHalfDay { get; set; }
    public int KmPerDay { get; set; }
    public int PricePerHalfDay { get; set; }
    public int PricePerDay { get; set; }
    public int PricePerDayWeekend { get; set; }
    public int PricePerWeekend { get; set; }
    public int PricePerWeek { get; set; }
    public int PricePerMonth { get; set; }
    public int BrandId { get; set; }
    [ForeignKey("BrandId")]
    public virtual BrandDto Brand { get; set; }
    public int? DepartamentId { get; set; }
    [ForeignKey("DepartamentId")]
    public virtual DepartmentDto Departament { get; set; }


}

