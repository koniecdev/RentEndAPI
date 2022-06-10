using Application.Dto;
using Domain.Entities;

namespace Application.Interfaces;
public interface IBrandService
{
	IEnumerable<BrandDto> GetAllBrands();
	BrandDto GetById(int id);
	BrandDto AddNewBrand(CreateBrandDto newBrand);
	public void UpdateBrand(UpdateBrandDto newBrand);
}

