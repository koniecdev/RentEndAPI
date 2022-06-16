using Application.Dto;
using Application.Interfaces;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Reflection;

namespace Application.Services;
public class CarService : ICarService
{
	private readonly ICarRepository _carRepository;
	private readonly IMapper _mapper;

	public CarService(ICarRepository carRepository, IMapper mapper)
	{
		_carRepository = carRepository;
		_mapper = mapper;
	}
	public IEnumerable<CarDto> GetAllCars()
	{
		var cars = _carRepository.GetAll();
		return _mapper.Map<IEnumerable<CarDto>>(cars);
	}

	public CarDto GetById(int id)
	{
		var car = _carRepository.GetById(id);
		return _mapper.Map<CarDto>(car);
	}

	public CarDto AddNewCar(CreateCarDto newBrand)
	{
		var mapped = _mapper.Map<Car>(newBrand);
		var car = _carRepository.Add(mapped);
		return _mapper.Map<CarDto>(car);
	}
	public void UpdateCar(int id, UpdateCarDto newBrand)
	{
		Car carOrigin = _carRepository.GetById(id); // this should be db object with props from newBrand
		if(carOrigin != null)
		{
			var returned = PatchRequestMap.PatchMap(carOrigin, newBrand);
			_carRepository.Update(returned);
		}
	}

	public void DeleteCar(int id)
	{
		var car = _carRepository.GetById(id);
		_carRepository.Delete(car);
	}
}