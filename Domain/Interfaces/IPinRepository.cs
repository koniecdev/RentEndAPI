using Domain.Entities;

namespace Domain.Interfaces;
public interface IPinRepository
{
	IEnumerable<Pin> GetAll();
	Pin GetById(int id);
	Pin Add(Pin pin);
	void Update(Pin pin);
	void Delete(Pin pin);
}
