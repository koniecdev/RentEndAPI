using Domain.Entities;

namespace Domain.Interfaces;
public interface ICarRepository
{
	Task<IEnumerable<Car>> GetAll();
	Task<Car> GetById(int id);
	Task<Car> Add(Car car);
	Task Update(Car car);
	Task Delete(Car car);
}
