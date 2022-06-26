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

	public async Task<IEnumerable<BrandDto>> GetAllBrands()
	{
		var x = await _brandRepository.GetAll();
		return _mapper.Map<IEnumerable<BrandDto>>(x);
	}

	public async Task<BrandDto> GetById(int id)
	{
		var x = await _brandRepository.GetById(id);
		return _mapper.Map<BrandDto>(x);
	}

	public async Task<BrandDto> AddNewBrand(CreateBrandDto newBrand)
	{
		var brand = _mapper.Map<Brand>(newBrand);
		await _brandRepository.Add(brand);
		return _mapper.Map<BrandDto>(brand);
	}

	public async Task UpdateBrand(int id, UpdateBrandDto updatedBrand)
	{
		var fromDb = await _brandRepository.GetById(id);
		if(updatedBrand != null && fromDb != null)
		{
			var returned = PatchRequestMap.PatchMap(fromDb, updatedBrand);
			await _brandRepository.Update(returned);
		}
	}

	public async Task DeleteBrand(int id)
	{
		var fromDb = await _brandRepository.GetById(id);
		if(fromDb != null)
		{
			await _brandRepository.Delete(fromDb);
		}
	}
}