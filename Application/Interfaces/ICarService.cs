using Application.Dto;
using Domain.Entities;

namespace Application.Interfaces;
public interface ICarService
{
	Task<IEnumerable<CarDto>> GetAllCars();
	Task<CarDto> GetById(int id);
	Task<CarDto> AddNewCar(CreateCarDto newBrand);
	public Task UpdateCar(int id, UpdateCarDto newBrand);
	public Task DeleteCar(int id);
}

