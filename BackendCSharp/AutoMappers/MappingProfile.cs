using System;
using AutoMapper;
using BackendCSharp.DTOs;
using BackendCSharp.Models;

namespace BackendCSharp.AutoMappers
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<BeerInsertDTO, Beer>();
			CreateMap<Beer, BeerDTO>()
				.ForMember(dto => dto.Id,
				           m => m.MapFrom(b => b.BeerID));
            CreateMap<BeerUpdateDTO, Beer>();
        }
	}
}

