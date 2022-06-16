using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class DepartmentRepository : IDepartmentRepository
{
	private readonly RentendContext _db;
	public DepartmentRepository(RentendContext db)
	{
		_db = db;
	}
	public IEnumerable<Department> GetAll()
	{
		return _db.Departments.ToList();
	}
	public Department GetById(int id)
	{
		var r = _db.Departments.FirstOrDefault(m => m.Id.Equals(id));
		if(r == null)
		{
			throw new Exception("No such item exists");
		}
		return r;
	}
	public Department Add(Department department)
	{
		department.Created = DateTime.UtcNow;
		_db.Departments.Add(department);
		_db.SaveChanges();
		return department;
	}
	public void Update(Department department)
	{
		department.LastModified = DateTime.UtcNow;
		_db.SaveChanges();
	}
	public void Delete(Department department)
	{
		_db.Departments.Remove(department);
		_db.SaveChanges();
	}
}

