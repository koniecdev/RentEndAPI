using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class PinRepository : IPinRepository
{
	private readonly RentendContext _db;
	public PinRepository(RentendContext db)
	{
		_db = db;
	}
	public IEnumerable<Pin> GetAll()
	{
		return _db.Pins.Include(m => m.Car).ThenInclude(m => m.Brand).ToList();
	}
	public Pin GetById(int id)
	{
		var r = _db.Pins.Include(m=>m.Car).ThenInclude(m=>m.Brand).FirstOrDefault(m => m.Id.Equals(id));
		if(r == null)
		{
			throw new Exception("No such item exists");
		}
		return r;
	}
	public Pin Add(Pin pin)
	{
		pin.Created = DateTime.UtcNow;
		_db.Pins.Add(pin);
		_db.SaveChanges();
		return pin;
	}
	public void Update(Pin pin)
	{
		pin.LastModified = DateTime.UtcNow;
		_db.SaveChanges();
	}
	public void Delete(Pin pin)
	{
		_db.Pins.Remove(pin);
		_db.SaveChanges();
	}
}

