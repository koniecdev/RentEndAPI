using Application.Dto;
using Domain.Entities;

namespace Application.Interfaces;
public interface IDepartmentService
{
	IEnumerable<DepartmentDto> GetAllDepartments();
	DepartmentDto GetById(int id);
	DepartmentDto AddNewDepartment(CreateDepartmentDto newBrand);
	public void UpdateDepartment(int id, UpdateDepartmentDto newBrand);
	public void DeleteDepartment(int id);
}

