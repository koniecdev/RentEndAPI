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
	public async Task<IEnumerable<Pin>> GetAll()
	{
		var list = await _db.Pins.Include(m => m.Car).ThenInclude(m => m.Brand).ToListAsync();
		return list;
	}
	public async Task<Pin> GetById(int id)
	{
		var r = await _db.Pins.Include(m=>m.Car).ThenInclude(m=>m.Brand).FirstOrDefaultAsync(m => m.Id.Equals(id));
		if(r == null)
		{
			throw new Exception("No such item exists");
		}
		return r;
	}
	public async Task<Pin> Add(Pin pin)
	{
		pin.Created = DateTime.UtcNow;
		_db.Pins.Add(pin);
		await _db.SaveChangesAsync();
		return pin;
	}
	public async Task Update(Pin pin)
	{
		pin.LastModified = DateTime.UtcNow;
		await _db.SaveChangesAsync();
	}
	public async Task Delete(Pin pin)
	{
		_db.Pins.Remove(pin);
		await _db.SaveChangesAsync();
	}
}

