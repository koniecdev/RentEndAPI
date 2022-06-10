using Application.Dto;
using Application.Interfaces;
using AutoMapper;
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
		var x = _brandRepository.GetByIdAsync(id);
		return _mapper.Map<BrandDto>(x);
	}
}