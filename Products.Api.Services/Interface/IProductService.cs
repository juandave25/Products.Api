using Products.Api.Entities;
using Products.Api.Entities.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Api.Services.Interface
{
    public interface IProductService
    {
        Task<ApiResponse<Product>> AddProduct(Product product);
        Task<ApiResponse<string>> DeleteProduct(int id);
        Task<ApiResponse<List<Product>>> GetAllProducts();
        Task<ApiResponse<List<Product>>> GetProducts(string name, int? minPrice, int? maxPrice);
        Task<ApiResponse<Product>> UpdateProduct(int id, Product product);
    }
}
