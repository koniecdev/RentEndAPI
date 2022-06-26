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
	public async Task<IEnumerable<CarDto>> GetAllCars()
	{
		var cars = await _carRepository.GetAll();
		return _mapper.Map<IEnumerable<CarDto>>(cars);
	}

	public async Task<CarDto> GetById(int id)
	{
		var car = await _carRepository.GetById(id);
		return _mapper.Map<CarDto>(car);
	}

	public async Task<CarDto> AddNewCar(CreateCarDto newBrand)
	{
		var mapped = _mapper.Map<Car>(newBrand);
		var car = await _carRepository.Add(mapped);
		return _mapper.Map<CarDto>(car);
	}
	public async Task UpdateCar(int id, UpdateCarDto newBrand)
	{
		Car carOrigin = await _carRepository.GetById(id); // this should be db object with props from newBrand
		if(carOrigin != null)
		{
			var returned = PatchRequestMap.PatchMap(carOrigin, newBrand);
			await _carRepository.Update(returned);
		}
		else
		{
			throw new Exception("item not found");
		}
	}

	public async Task DeleteCar(int id)
	{
		var car = await _carRepository.GetById(id);
		if (car == null)
		{
			throw new Exception("item not found");
		}
		await _carRepository.Delete(car);
	}
}