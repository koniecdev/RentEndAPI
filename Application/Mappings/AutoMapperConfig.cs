﻿using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;
public static class AutoMapperConfig
{
	public static IMapper Initialize() =>
		new MapperConfiguration(cfg =>
		{
			cfg.CreateMap<Brand, BrandDto>();
		}).CreateMapper();
}