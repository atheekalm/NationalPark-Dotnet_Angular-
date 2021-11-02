using AutoMapper;
using Dotnet_WebAPI.Models;
using Dotnet_WebAPI.Models.Dtos;
using Models;
using Models.Dtos;

namespace Dotnet_WebAPI.mapper
{
    public class NationalParkMapper : Profile
    {
        public NationalParkMapper()
        {
            CreateMap<NationalPark, NationalParkDtos>().ReverseMap();
            CreateMap<Trails, TrailsDtos>().ReverseMap();
            CreateMap<Trails, UpdeDtos>().ReverseMap();
        }
    }
}