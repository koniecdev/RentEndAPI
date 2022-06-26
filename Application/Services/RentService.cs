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

	public async Task<IEnumerable<RentDto>> GetAllRents()
	{
		var fromDb = await _repository.GetAll();
		return _mapper.Map<IEnumerable<RentDto>>(fromDb);
	}

	public async Task<IEnumerable<RentDto>> GetAllRents(int departmentId, DateTime since, DateTime until)
	{
		var fromDb = await _repository.GetAll(departmentId, since, until);
		return _mapper.Map<IEnumerable<RentDto>>(fromDb);
	}

	public async Task<RentDto> GetById(int id)
	{
		var fromDb = await _repository.GetById(id);
		return _mapper.Map<RentDto>(fromDb);
	}

	public async Task<RentDto> AddNewRent(CreateRentDto dto)
	{
		var mapped = _mapper.Map<Rent>(dto);
		await _repository.Add(mapped);
		return _mapper.Map<RentDto>(mapped);
	}

	public async Task UpdateRent(int id, UpdateRentDto dto)
	{
		var fromDb = await _repository.GetById(id);
		if(dto != null)
		{
			var returned = PatchRequestMap.PatchMap(fromDb, dto);
			await _repository.Update(returned);
		}
	}

	public async Task DeleteRent(int id)
	{
		var fromDb = await _repository.GetById(id);
		if (fromDb != null)
		{
			await _repository.Delete(fromDb);
		}
	}
}