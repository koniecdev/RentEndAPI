using Domain.Entities;

namespace Domain.Interfaces;
public interface ICarRepository
{
	IEnumerable<Car> GetAll();
	Car GetById(int id);
	Car Add(Car car);
	void Update(Car car);
	void Delete(Car car);
}
