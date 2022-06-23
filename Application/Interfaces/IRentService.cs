using Application.Dto;
using Domain.Entities;

namespace Application.Interfaces;
public interface IRentService
{
	IEnumerable<RentDto> GetAllRents();
	IEnumerable<RentDto> GetAllRents(int departmentId, DateTime since, DateTime until);
	RentDto GetById(int id);
	RentDto AddNewRent(CreateRentDto newBrand);
	public void UpdateRent(int id, UpdateRentDto newBrand);
	public void DeleteRent(int id);
}

