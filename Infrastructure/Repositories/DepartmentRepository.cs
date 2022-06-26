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
	public async Task<IEnumerable<Department>> GetAll()
	{
		var list = await _db.Departments.ToListAsync();
		return list;
	}
	public async Task<Department> GetById(int id)
	{
		var r = await _db.Departments.FirstOrDefaultAsync(m => m.Id.Equals(id));
		if(r == null)
		{
			throw new Exception("No such item exists");
		}
		return r;
	}
	public async Task<Department> Add(Department department)
	{
		department.Created = DateTime.UtcNow;
		_db.Departments.Add(department);
		await _db.SaveChangesAsync();
		return department;
	}
	public async Task Update(Department department)
	{
		department.LastModified = DateTime.UtcNow;
		await _db.SaveChangesAsync();
	}
	public async Task Delete(Department department)
	{
		_db.Departments.Remove(department);
		await _db.SaveChangesAsync();
	}
}

