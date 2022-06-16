using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class CarRepository : ICarRepository
{
	private readonly RentendContext _db;
	//private static readonly List<Brand> brands = new()
	//{
	//	new Brand(1, "Honda"),
	//	new Brand(2, "Mitsubishi"),
	//	new Brand(3, "Toyota")
	//};
	public CarRepository(RentendContext db)
	{
		_db = db;
	}
	public IEnumerable<Car> GetAll()
	{
		var list = _db.Cars.Include(m => m.Brand).Include(m => m.Departament).ToList();
		return list;
	}

	public Car GetById(int id)
	{
		var x = _db.Cars.Include(m => m.Brand).Include(m => m.Departament).FirstOrDefault(m => m.Id.Equals(id));
		return x;
	}

	public Car Add(Car car)
	{
		_db.Cars.Add(car);
		_db.SaveChanges();
		return car;
	}

	public void Update(Car car)
	{
		car.LastModified = DateTime.Now;
		_db.SaveChanges();
	}

	public void Delete(Car car)
	{
		_db.Cars.Remove(car);
		_db.SaveChanges();
	}
}

