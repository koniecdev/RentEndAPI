using Domain.Entities;

namespace Domain.Interfaces;
public interface IRentRepository
{
	IEnumerable<Rent> GetAll();
	IEnumerable<Rent> GetAll(int departmentId, DateTime since, DateTime until);
	Rent GetById(int id);
	Rent Add(Rent rent);
	void Update(Rent rent);
	void Delete(Rent rent);
}
