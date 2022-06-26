using Application.Dto;
using Domain.Entities;

namespace Application.Interfaces;
public interface IDepartmentService
{
	Task<IEnumerable<DepartmentDto>> GetAllDepartments();
	Task<DepartmentDto> GetById(int id);
	Task<DepartmentDto> AddNewDepartment(CreateDepartmentDto newBrand);
	public Task UpdateDepartment(int id, UpdateDepartmentDto newBrand);
	public Task DeleteDepartment(int id);
}

