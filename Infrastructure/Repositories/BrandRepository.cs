using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;
public class BrandRepository : IBrandRepository
{
	private static readonly List<Brand> brands = new()
	{
		new Brand(1, "Honda"),
		new Brand(2, "Mitsubishi"),
		new Brand(3, "Toyota")
	};

	public IEnumerable<Brand> GetAll()
	{
		return brands;
	}
	public Brand GetByIdAsync(int id)
	{
		return brands.FirstOrDefault(m=>m.Id.Equals(id));
	}
	public Brand Add(Brand brand)
	{
		int Id = brands.Max(m => m.Id) + 1;
		brand.Id = Id;
		brand.Created = DateTime.UtcNow;
		brands.Add(brand);
		return brand;
	}
	public void Update(Brand brand)
	{
		brand.LastModified = DateTime.UtcNow;
	}
	public void Delete(Brand brand)
	{
		brands.Remove(brand);
	}
}

