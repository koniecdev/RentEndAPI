using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;
public static class AutoMapperConfig
{
	public static IMapper Initialize() =>
		new MapperConfiguration(cfg =>
		{
			cfg.CreateMap<Brand, BrandDto>();
			cfg.CreateMap<CreateBrandDto, Brand>();
			cfg.CreateMap<UpdateBrandDto, Brand>();
			cfg.CreateMap<Car, CarDto>();
			cfg.CreateMap<CreateCarDto, Car>();
			cfg.CreateMap<UpdateCarDto, Car>();
			cfg.CreateMap<Department, DepartmentDto>();
			cfg.CreateMap<CreateDepartmentDto, Department>();
			cfg.CreateMap<UpdateDepartmentDto, Department>();
			cfg.CreateMap<Pin, PinDto>();
			cfg.CreateMap<CreatePinDto, Pin>();
			cfg.CreateMap<UpdatePinDto, Pin>();
		}).CreateMapper();
}