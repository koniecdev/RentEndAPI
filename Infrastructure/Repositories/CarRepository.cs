using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Repositories;
public class CarRepository : ICarRepository
{
	private readonly RentendContext _db;
	public CarRepository(RentendContext db)
	{
		_db = db;
	}
	public async Task<IEnumerable<Car>> GetAll()
	{
		var list = await _db.Cars.Include(m => m.Brand).Include(m => m.Departament).ToListAsync();
		return list;
	}
	public async Task<Car> GetById(int id)
	{
		var x = await _db.Cars.Include(m => m.Brand).Include(m => m.Departament).FirstOrDefaultAsync(m => m.Id.Equals(id));
		if(x == null)
		{
			throw new Exception("No item found");
		}
		return x;
	}

	public async Task<Car> Add(Car car)
	{
		_db.Cars.Add(car);
		await _db.SaveChangesAsync();
		return car;
	}

	public async Task Update(Car car)
	{
		car.LastModified = DateTime.Now;
		await _db.SaveChangesAsync();
	}

	public async Task Delete(Car car)
	{
		_db.Cars.Remove(car);
		await _db.SaveChangesAsync();
	}

}

