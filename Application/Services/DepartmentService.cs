using Application.Dto;
using Application.Interfaces;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;
public class DepartmentService : IDepartmentService
{
	private readonly IDepartmentRepository _repository;
	private readonly IMapper _mapper;
	public DepartmentService(IDepartmentRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<DepartmentDto>> GetAllDepartments()
	{
		var fromDb = await _repository.GetAll();
		return _mapper.Map<IEnumerable<DepartmentDto>>(fromDb);
	}

	public async Task<DepartmentDto> GetById(int id)
	{
		var fromDb = await _repository.GetById(id);
		return _mapper.Map<DepartmentDto>(fromDb);
	}

	public async Task<DepartmentDto> AddNewDepartment(CreateDepartmentDto dto)
	{
		var mapped = _mapper.Map<Department>(dto);
		await _repository.Add(mapped);
		return _mapper.Map<DepartmentDto>(mapped);
	}

	public async Task UpdateDepartment(int id, UpdateDepartmentDto dto)
	{
		var fromDb = await _repository.GetById(id);
		if(dto != null)
		{
			var returned = PatchRequestMap.PatchMap(fromDb, dto);
			await _repository.Update(returned);
		}
	}

	public async Task DeleteDepartment(int id)
	{
		var fromDb = await _repository.GetById(id);
		if(fromDb != null)
		{
			await _repository.Delete(fromDb);
		}
	}
}