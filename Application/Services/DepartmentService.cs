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

	public IEnumerable<DepartmentDto> GetAllDepartments()
	{
		var fromDb = _repository.GetAll();
		return _mapper.Map<IEnumerable<DepartmentDto>>(fromDb);
	}

	public DepartmentDto GetById(int id)
	{
		var fromDb = _repository.GetById(id);
		return _mapper.Map<DepartmentDto>(fromDb);
	}

	public DepartmentDto AddNewDepartment(CreateDepartmentDto dto)
	{
		var mapped = _mapper.Map<Department>(dto);
		_repository.Add(mapped);
		return _mapper.Map<DepartmentDto>(mapped);
	}

	public void UpdateDepartment(int id, UpdateDepartmentDto dto)
	{
		var fromDb = _repository.GetById(id);
		if(dto != null)
		{
			var returned = PatchRequestMap.PatchMap(fromDb, dto);
			_repository.Update(returned);
		}
	}

	public void DeleteDepartment(int id)
	{
		var fromDb = _repository.GetById(id);
		_repository.Delete(fromDb);
	}
}