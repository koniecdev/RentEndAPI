using Domain.Entities;

namespace Domain.Interfaces;
public interface IRentRepository
{
	Task<IEnumerable<Rent>> GetAll();
	Task<IEnumerable<Rent>> GetAll(int departmentId, DateTime since, DateTime until);
	Task<Rent> GetById(int id);
	Task<Rent> Add(Rent rent);
	Task Update(Rent rent);
	Task Delete(Rent rent);
}
