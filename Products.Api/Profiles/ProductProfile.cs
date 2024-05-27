using AutoMapper;
using Products.Api.Entities;
using Products.Api.Entities.Dto.Product;

namespace Products.Api.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddproductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();
            CreateMap<Product, Products.Api.Data.Models.Product>();
        }
    }
}
