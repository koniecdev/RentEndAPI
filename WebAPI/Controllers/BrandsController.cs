using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController : ControllerBase
	{
		private readonly IBrandService _brandService;
		public BrandsController(IBrandService brandService)
		{
			_brandService = brandService;
		}
		[HttpGet]
		public IActionResult Get()
		{
			var brands = _brandService.GetAllBrands();
			if(brands == null)
			{
				return NotFound();
			}
			return Ok(brands);
		}
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			if(id <= 0)
			{
				return NotFound();
			}
			var brand = _brandService.GetById(id);
			if(brand == null)
			{
				return NotFound();
			}
			return Ok(brand);
		}
		[HttpPost]
		public IActionResult Create(CreateBrandDto createBrandDto)
		{
			if(createBrandDto == null)
			{
				return BadRequest();
			}
			if(string.IsNullOrWhiteSpace(createBrandDto.Name))
			{
				return UnprocessableEntity();
			}
			var brand = _brandService.AddNewBrand(createBrandDto);
			return Created($"api/Brands/{brand.Id}", brand);
		}
		[HttpPatch("{id}")]
		public IActionResult Update(int id, UpdateBrandDto updateBrandDto)
		{
			if(id <= 0)
			{
				return NotFound();
			}
			var fromDb = _brandService.GetById(id);
			if (fromDb == null)
			{
				return NotFound();
			}
			_brandService.UpdateBrand(id, updateBrandDto);
			return NoContent();
		}
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			if(id == 0)
			{
				return NotFound();
			}
			var fromDb = _brandService.GetById(id);
			if(fromDb == null)
			{
				return NotFound();
			}
			_brandService.DeleteBrand(id);
			return NoContent();
		}
	}
}
