using AutoMapper;
using Products.Api.Data.Models;
using Products.Api.Data.Repository.Interface;
using Products.Api.Entities.Response;
using Products.Api.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Api.Services
{
    public class ProductService : IProductService
    {

        readonly IProductRepositorty _productRepository;
        readonly IMapper _mapper;

        public ProductService(IProductRepositorty productRepositorty, IMapper mapper)
        {

            _productRepository = productRepositorty;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Products.Api.Entities.Product>> AddProduct(Products.Api.Entities.Product product)
        {
            var productData = _mapper.Map<Product>(product);
            var response = _mapper.Map<ApiResponse<Products.Api.Entities.Product>>(await _productRepository.AddProduct(productData));
            return response;
        }

        public async Task<ApiResponse<string>> DeleteProduct(int id)
        {
            var response = await _productRepository.DeleteProduct(id);
            return response;
        }

        public async Task<ApiResponse<List<Entities.Product>>> GetAllProducts()
        {
            var response = _mapper.Map<ApiResponse<List<Entities.Product>>>(await _productRepository.GetAllProducts());
            return response;
        }

        public async Task<ApiResponse<List<Entities.Product>>> GetProducts(string name, int? minPrice, int? maxPrice)
        {
            var response = _mapper.Map<ApiResponse<List<Products.Api.Entities.Product>>>(await _productRepository.GetProducts(name, minPrice, maxPrice));
            return response;
        }

        public async Task<ApiResponse<Entities.Product>> UpdateProduct(int id, Products.Api.Entities.Product product)
        {
            var productData = _mapper.Map<Product>(product);
            var response = _mapper.Map<ApiResponse<Products.Api.Entities.Product>>(await _productRepository.UpdateProduct(id, productData));
            return response;
        }
    }
}
