using Domain.Entities;

namespace Domain.Interfaces;
public interface IDepartmentRepository
{
	Task<IEnumerable<Department>> GetAll();
	Task<Department> GetById(int id);
	Task<Department> Add(Department department);
	Task Update(Department department);
	Task Delete(Department department);
}
