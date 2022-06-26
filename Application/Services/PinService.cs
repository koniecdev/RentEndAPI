using Application.Dto;
using Application.Interfaces;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;
public class PinService : IPinService
{
	private readonly IPinRepository _repository;
	private readonly IMapper _mapper;
	public PinService(IPinRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<PinDto>> GetAllPins()
	{
		var fromDb = await _repository.GetAll();
		return _mapper.Map<IEnumerable<PinDto>>(fromDb);
	}

	public async Task<PinDto> GetById(int id)
	{
		var fromDb = await _repository.GetById(id);
		return _mapper.Map<PinDto>(fromDb);
	}

	public async Task<PinDto> AddNewPin(CreatePinDto dto)
	{
		var mapped = _mapper.Map<Pin>(dto);
		await _repository.Add(mapped);
		return _mapper.Map<PinDto>(mapped);
	}

	public async Task UpdatePin(int id, UpdatePinDto dto)
	{
		var fromDb = await _repository.GetById(id);
		if(dto != null)
		{
			var returned = PatchRequestMap.PatchMap(fromDb, dto);
			await _repository.Update(returned);
		}
	}

	public async Task DeletePin(int id)
	{
		var fromDb = await _repository.GetById(id);
		if(fromDb == null)
		{
			throw new Exception("not found");
		}
		await _repository.Delete(fromDb);
	}
}