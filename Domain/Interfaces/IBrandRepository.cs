using Domain.Entities;

namespace Domain.Interfaces;
public interface IBrandRepository
{
	Task<IEnumerable<Brand>> GetAll();
	Task<Brand> GetById(int id);
	Brand Add(Brand brand);
	void Update(Brand brand);
	void Delete(Brand brand);
}
