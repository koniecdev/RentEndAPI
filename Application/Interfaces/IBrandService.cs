using Application.Dto;
using Domain.Entities;

namespace Application.Interfaces;
public interface IBrandService
{
	Task<IEnumerable<BrandDto>> GetAllBrands();
	Task<BrandDto> GetById(int id);
	Task<BrandDto> AddNewBrand(CreateBrandDto newBrand);
	public Task UpdateBrand(int id, UpdateBrandDto newBrand);
	public Task DeleteBrand(int id);
}

