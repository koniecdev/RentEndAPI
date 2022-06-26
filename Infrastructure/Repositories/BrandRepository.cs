using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class BrandRepository : IBrandRepository
{
	private readonly RentendContext _db;
	public BrandRepository(RentendContext db)
	{
		_db = db;
	}
	public async Task<IEnumerable<Brand>> GetAll()
	{
		var list = await _db.Brands.ToListAsync();
		return list;
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
	public async Task<Brand> Add(Brand brand)
	{
		brand.Created = DateTime.UtcNow;
		_db.Brands.Add(brand);
		await _db.SaveChangesAsync();
		return brand;
	}
	public async Task Update(Brand brand)
	{
		brand.LastModified = DateTime.UtcNow;
		await _db.SaveChangesAsync();
	}
	public async Task Delete(Brand brand)
	{
		_db.Brands.Remove(brand);
		await _db.SaveChangesAsync();
	}
}

