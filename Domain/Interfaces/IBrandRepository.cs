using Domain.Entities;

namespace Domain.Interfaces;
public interface IBrandRepository
{
	IEnumerable<Brand> GetAll();
	Brand GetByIdAsync(int id);
	Brand Add(Brand brand);
	void Update(Brand brand);
	void Delete(Brand brand);
}
