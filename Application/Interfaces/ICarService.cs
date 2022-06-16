using Application.Dto;
using Domain.Entities;

namespace Application.Interfaces;
public interface ICarService
{
	IEnumerable<CarDto> GetAllCars();
	CarDto GetById(int id);
	CarDto AddNewCar(CreateCarDto newBrand);
	public void UpdateCar(int id, UpdateCarDto newBrand);
	public void DeleteCar(int id);
}

