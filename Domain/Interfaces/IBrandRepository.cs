using Domain.Entities;

namespace Domain.Interfaces;
public interface IBrandRepository
{
	Task<IEnumerable<Brand>> GetAll();
	Task<Brand> GetById(int id);
	Task<Brand> Add(Brand brand);
	Task Update(Brand brand);
	Task Delete(Brand brand);
}
