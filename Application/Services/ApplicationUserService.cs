using Application.Dto;
using Application.Interfaces;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;
public class ApplicationUserService : IApplicationUserService
{
	private readonly IApplicationUserRepository _repository;
	private readonly IMapper _mapper;
	public ApplicationUserService(IApplicationUserRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<ApplicationUserDto>> GetAllApplicationUsers()
	{
		var fromDb = await _repository.GetAll();
		return _mapper.Map<IEnumerable<ApplicationUserDto>>(fromDb);
	}

	public async Task<ApplicationUserDto> GetById(string id)
	{
		var fromDb = await _repository.GetById(id);
		return _mapper.Map<ApplicationUserDto>(fromDb);
	}

	public async Task<ApplicationUserDto> AddNewApplicationUser(CreateApplicationUserDto dto, string password)
	{
		var mapped = _mapper.Map<ApplicationUser>(dto);
		await _repository.Add(mapped, password);
		return _mapper.Map<ApplicationUserDto>(mapped);
	}

	public async Task UpdateApplicationUser(string id, UpdateApplicationUserDto dto)
	{
		var fromDb = await _repository.GetById(id);
		if(dto != null)
		{
			var returned = PatchRequestMap.PatchMap(fromDb, dto);
			await _repository.Update(returned);
		}
	}

	public async Task UpdateApplicationUser(string id, string password)
	{
		var fromDb = await _repository.GetById(id);
		if(fromDb != null)
		{
			await _repository.Update(fromDb, password);
		}
	}

	public async Task DeleteApplicationUser(string id)
	{
		var fromDb = await _repository.GetById(id);
		if(fromDb != null)
		{
			await _repository.Delete(fromDb);
		}
	}
}