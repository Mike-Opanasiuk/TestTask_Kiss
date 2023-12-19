using Api.Entities;
using Api.Models;
using AutoMapper;

namespace Api;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ImageEntity, ImageDto>();
    }
}
