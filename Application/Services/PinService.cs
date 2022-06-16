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

	public IEnumerable<PinDto> GetAllPins()
	{
		var fromDb = _repository.GetAll();
		return _mapper.Map<IEnumerable<PinDto>>(fromDb);
	}

	public PinDto GetById(int id)
	{
		var fromDb = _repository.GetById(id);
		return _mapper.Map<PinDto>(fromDb);
	}

	public PinDto AddNewPin(CreatePinDto dto)
	{
		var mapped = _mapper.Map<Pin>(dto);
		_repository.Add(mapped);
		return _mapper.Map<PinDto>(mapped);
	}

	public void UpdatePin(int id, UpdatePinDto dto)
	{
		var fromDb = _repository.GetById(id);
		if(dto != null)
		{
			var returned = PatchRequestMap.PatchMap(fromDb, dto);
			_repository.Update(returned);
		}
	}

	public void DeletePin(int id)
	{
		var fromDb = _repository.GetById(id);
		_repository.Delete(fromDb);
	}
}