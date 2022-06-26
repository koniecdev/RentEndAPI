using Application.Dto;
using Domain.Entities;

namespace Application.Interfaces;
public interface IRentService
{
	Task<IEnumerable<RentDto>> GetAllRents();
	Task<IEnumerable<RentDto>> GetAllRents(int departmentId, DateTime since, DateTime until);
	Task<RentDto> GetById(int id);
	Task<RentDto> AddNewRent(CreateRentDto newBrand);
	public Task UpdateRent(int id, UpdateRentDto newBrand);
	public Task DeleteRent(int id);
}

