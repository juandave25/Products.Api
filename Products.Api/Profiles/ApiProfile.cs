using AutoMapper;
using Products.Api.Entities.Response;
using System.Collections.Generic;
using Products.Api.Data.Models;
using System.Linq;
using System.Security.AccessControl;

namespace Products.Api.Profiles
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<Product, Entities.Product>().ReverseMap();
            CreateMap<ApiResponse<List<Product>>, ApiResponse<List<Entities.Product>>>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data));

            CreateMap<ApiResponse<Product>, ApiResponse<Entities.Product>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data));
        }
    }
}
