using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class CarRepository : ICarRepository
{
	private readonly RentendContext _db;
	public CarRepository(RentendContext db)
	{
		_db = db;
	}
	public IEnumerable<Car> GetAll()
	{
		var list = _db.Cars.Include(m => m.Brand).Include(m => m.Departament).ToList();
		return list;
	}
	public IEnumerable<Car> GetAll(int departmentId, DateTime since, DateTime until)
	{
		var list = _db.Cars.Include(m => m.Brand).Include(m => m.Departament).Where(m => m.DepartamentId.Equals(departmentId)).ToList();
		var rents = _db.Rent.Include(m=>m.Car).Where(m=>m.Car.DepartamentId.Equals(departmentId) && (m.Since >= since || m.Until <= until)).Select(m=>m.Car).ToList();
		//ToDo: Your first unit test, test this method, czy podana data nie koliduje z zadnym rentem z rents
		return list.Except(rents);
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

