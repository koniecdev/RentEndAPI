using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class RentRepository : IRentRepository
{
	private readonly RentendContext _db;
	public RentRepository(RentendContext db)
	{
		_db = db;
	}
	public async Task<IEnumerable<Rent>> GetAll()
	{
		return await _db.Rent.ToListAsync();
	}
	public async Task<IEnumerable<Rent>> GetAll(int departmentId, DateTime since, DateTime until)
	{
		return await _db.Rent.Include(m => m.Car).Where(m => m.Car.DepartamentId.Equals(departmentId) && (since <= m.Until) && (until >= m.Since)).ToListAsync();

	}
	public async Task<Rent> GetById(int id)
	{
		var r = await _db.Rent.FirstOrDefaultAsync(m => m.Id.Equals(id));
		if(r == null)
		{
			throw new Exception("No such item exists");
		}
		return r;
	}
	public async Task<Rent> Add(Rent rent)
	{
		rent.Created = DateTime.UtcNow;
		_db.Rent.Add(rent);
		await _db.SaveChangesAsync();
		return rent;
	}
	public async Task Update(Rent rent)
	{
		rent.LastModified = DateTime.UtcNow;
		await _db.SaveChangesAsync();
	}
	public async Task Delete(Rent rent)
	{
		_db.Rent.Remove(rent);
		await _db.SaveChangesAsync();
	}
}

