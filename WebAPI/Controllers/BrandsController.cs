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
		[HttpPut]
		public IActionResult Update(UpdateBrandDto updateBrandDto)
		{
			if(updateBrandDto.Id <= 0)
			{
				return NotFound();
			}
			var fromDb = _brandService.GetById(updateBrandDto.Id);
			if (fromDb == null)
			{
				return NotFound();
			}
			_brandService.UpdateBrand(updateBrandDto);
			return NoContent();
		}
	}
}
