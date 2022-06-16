using Domain.Entities;

namespace Domain.Interfaces;
public interface IDepartmentRepository
{
	IEnumerable<Department> GetAll();
	Department GetById(int id);
	Department Add(Department department);
	void Update(Department department);
	void Delete(Department department);
}
