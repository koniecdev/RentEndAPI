using Domain.Entities;

namespace Domain.Interfaces;
public interface IPinRepository
{
	Task<IEnumerable<Pin>> GetAll();
	Task<Pin> GetById(int id);
	Task<Pin> Add(Pin pin);
	Task Update(Pin pin);
	Task Delete(Pin pin);
}
