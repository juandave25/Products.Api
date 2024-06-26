﻿using Products.Api.Data.Models;
using Products.Api.Entities.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Api.Data.Repository.Interface
{
    /// <summary>
    /// Repository Class to connect to database.
    /// </summary>
    public interface IProductRepositorty
    {
        Task<ApiResponse<Product>> AddProduct(Product product);
        Task<ApiResponse<string>> DeleteProduct(int id);
        Task<ApiResponse<List<Product>>> GetAllProducts();
        Task<ApiResponse<List<Product>>> GetProducts(string name, int? minPrice, int? maxPrice);
        Task<ApiResponse<Product>> UpdateProduct(int id, Product product);
    }
}
