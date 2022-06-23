using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class RentRepository : IRentRepository
{
	private readonly RentendContext _db;
	//private static readonly List<Brand> brands = new()
	//{
	//	new Brand(1, "Honda"),
	//	new Brand(2, "Mitsubishi"),
	//	new Brand(3, "Toyota")
	//};
	public RentRepository(RentendContext db)
	{
		_db = db;
	}
	public IEnumerable<Rent> GetAll()
	{
		return _db.Rent.ToList();
	}
	public IEnumerable<Rent> GetAll(int departmentId, DateTime since, DateTime until)
	{
		return _db.Rent.Include(m => m.Car).Where(m => m.Car.DepartamentId.Equals(departmentId) && (since <= m.Until) && (until >= m.Since)).ToList();

	}
	public Rent GetById(int id)
	{
		var r = _db.Rent.FirstOrDefault(m => m.Id.Equals(id));
		if(r == null)
		{
			throw new Exception("No such item exists");
		}
		return r;
	}
	public Rent Add(Rent rent)
	{
		rent.Created = DateTime.UtcNow;
		_db.Rent.Add(rent);
		_db.SaveChanges();
		return rent;
	}
	public void Update(Rent rent)
	{
		rent.LastModified = DateTime.UtcNow;
		_db.SaveChanges();
	}
	public void Delete(Rent rent)
	{
		_db.Rent.Remove(rent);
		_db.SaveChanges();
	}
}

