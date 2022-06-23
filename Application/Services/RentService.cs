using Application.Dto;
using Application.Interfaces;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;
public class RentService : IRentService
{
	private readonly IRentRepository _repository;
	private readonly IMapper _mapper;
	public RentService(IRentRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public IEnumerable<RentDto> GetAllRents()
	{
		var fromDb = _repository.GetAll();
		return _mapper.Map<IEnumerable<RentDto>>(fromDb);
	}

	public IEnumerable<RentDto> GetAllRents(int departmentId, DateTime since, DateTime until)
	{
		var fromDb = _repository.GetAll(departmentId, since, until);
		return _mapper.Map<IEnumerable<RentDto>>(fromDb);
	}

	public RentDto GetById(int id)
	{
		var fromDb = _repository.GetById(id);
		return _mapper.Map<RentDto>(fromDb);
	}

	public RentDto AddNewRent(CreateRentDto dto)
	{
		var mapped = _mapper.Map<Rent>(dto);
		_repository.Add(mapped);
		return _mapper.Map<RentDto>(mapped);
	}

	public void UpdateRent(int id, UpdateRentDto dto)
	{
		var fromDb = _repository.GetById(id);
		if(dto != null)
		{
			var returned = PatchRequestMap.PatchMap(fromDb, dto);
			_repository.Update(returned);
		}
	}

	public void DeleteRent(int id)
	{
		var fromDb = _repository.GetById(id);
		_repository.Delete(fromDb);
	}
}