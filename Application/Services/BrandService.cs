using Application.Dto;
using Application.Interfaces;
using Application.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;
public class BrandService : IBrandService
{
	private readonly IBrandRepository _brandRepository;
	private readonly IMapper _mapper;
	public BrandService(IBrandRepository brandRepository, IMapper mapper)
	{
		_brandRepository = brandRepository;
		_mapper = mapper;
	}

	public IEnumerable<BrandDto> GetAllBrands()
	{
		var x = _brandRepository.GetAll();
		return _mapper.Map<IEnumerable<BrandDto>>(x);
	}

	public BrandDto GetById(int id)
	{
		var x = _brandRepository.GetById(id);
		return _mapper.Map<BrandDto>(x);
	}

	public BrandDto AddNewBrand(CreateBrandDto newBrand)
	{
		var brand = _mapper.Map<Brand>(newBrand);
		_brandRepository.Add(brand);
		return _mapper.Map<BrandDto>(brand);
	}

	public void UpdateBrand(int id, UpdateBrandDto updatedBrand)
	{
		var fromDb = _brandRepository.GetById(id);
		if(updatedBrand != null)
		{
			var returned = PatchRequestMap.PatchMap(fromDb, updatedBrand);
			_brandRepository.Update(returned);
		}
	}

	public void DeleteBrand(int id)
	{
		var fromDb = _brandRepository.GetById(id);
		_brandRepository.Delete(fromDb);
	}
}