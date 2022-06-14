using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class BrandRepository : IBrandRepository
{
	private readonly RentendContext _db;
	//private static readonly List<Brand> brands = new()
	//{
	//	new Brand(1, "Honda"),
	//	new Brand(2, "Mitsubishi"),
	//	new Brand(3, "Toyota")
	//};
	public BrandRepository(RentendContext db)
	{
		_db = db;
	}
	public async Task<IEnumerable<Brand>> GetAll()
	{
		return await _db.Brands.ToListAsync();
	}
	public async Task<Brand> GetById(int id)
	{
		var r = await _db.Brands.FirstOrDefaultAsync(m => m.Id.Equals(id));
		if(r == null)
		{
			throw new Exception("No such item exists");
		}
		return r;
	}
	public Brand Add(Brand brand)
	{
		brand.Created = DateTime.UtcNow;
		_db.Brands.Add(brand);
		_db.SaveChanges();
		return brand;
	}
	public void Update(Brand brand)
	{
		brand.LastModified = DateTime.UtcNow;
		_db.SaveChanges();
	}
	public void Delete(Brand brand)
	{
		_db.Brands.Remove(brand);
		_db.SaveChanges();
	}
}

