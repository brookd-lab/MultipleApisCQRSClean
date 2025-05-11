using AutoMapper;
using AutoMapperWebApi.Data.DTOs;
using AutoMapperWebApi.Data.Models;

namespace AutoMapperWebApi.Data.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Developer, DeveloperDTO>()
                .ForMember(dest => dest.MyExperience, source => source.MapFrom(source => source.Experience)) //Specific Mapping
                .ForMember(dest => dest.IsEmployed, source => source.MapFrom(source => source.Salary > 0 ? true : false)) //Conditional Mapping\
                .ReverseMap();
            CreateMap<Address, AddressDTO>();
        }
    }
}