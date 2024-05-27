using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Products.Api.Data.Models;
using Products.Api.Data.Repository.Interface;
using Products.Api.Entities.Exceptions;
using Products.Api.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Api.Data.Repository
{
    public class ProductRepository : IProductRepositorty
    {
        readonly IMapper _mapper;
        public ProductRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ApiResponse<Product>> AddProduct(Product product)
        {
            try
            {
                using var context = new Context();
                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();
                return _mapper.Map<ApiResponse<Product>>(new ApiResponse<Product>(product, "Product added successfully"));
            }
            catch (Exception ex)
            {
                return new ApiResponse<Product>("An error occurred while adding the product", new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<string>> DeleteProduct(int id)
        {
            try
            {
                using var context = new Context();
                var product = await context.Products.FindAsync(id) ?? throw new NotFoundException("Product not found");
                context.Products.Remove(product);
                await context.SaveChangesAsync();
                return new ApiResponse<string>("Product deleted successfully");
            }
            catch (NotFoundException ex)
            {
                return new ApiResponse<string>(ex.Message, new List<string> { ex.Message });
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>("An error occurred while deleting the product", new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<List<Product>>> GetAllProducts()
        {
            try
            {
                using var context = new Context();
                var result = await context.Products.ToListAsync();
                var response = _mapper.Map<ApiResponse<List<Product>>>(new ApiResponse<List<Product>>(result, "Products retrieved successfully"));
                return response;
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Product>>("An error occurred while retrieving products", new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<List<Product>>> GetProducts(string name, int? minPrice, int? maxPrice)
        {
            try
            {
                using var context = new Context();
                var query = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(p => p.Name.Contains(name));
                }

                if (minPrice.HasValue)
                {
                    query = query.Where(p => p.Price >= minPrice.Value);
                }

                if (maxPrice.HasValue)
                {
                    query = query.Where(p => p.Price <= maxPrice.Value);
                }
                var result = await query.ToListAsync();
                var response = _mapper.Map<ApiResponse<List<Product>>>(new ApiResponse<List<Product>>(result, result.Count > 0 ? "Products retrieved successfully" : "Product not found"));
                return response;
            }
            catch (NotFoundException ex)
            {
                return new ApiResponse<List<Product>>(ex.Message, new List<string> { ex.Message });
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Product>>("An error occurred while retrieving products", new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<Product>> UpdateProduct(int id, Product product)
        {
            try
            {
                using var context = new Context();
                var existingProduct = await context.Products.FindAsync(id) ?? throw new NotFoundException("Product not found");
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Category = product.Category;
                existingProduct.Description = product.Description;
                existingProduct.Quantity = product.Quantity;
                await context.SaveChangesAsync();

                return _mapper.Map<ApiResponse<Product>>(new ApiResponse<Product>(existingProduct, "Product updated successfully"));
            }
            catch (NotFoundException ex)
            {
                return new ApiResponse<Product>(ex.Message, new List<string> { ex.Message });
            }
            catch (Exception ex)
            {
                return new ApiResponse<Product>("An error occurred while updating the product", new List<string> { ex.Message });
            }
        }
    }
}
