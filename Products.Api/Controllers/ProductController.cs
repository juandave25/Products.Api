using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Products.Api.Services.Interface;
using Products.Api.Data.Models;
using System.Net;
using AutoMapper;
using Products.Api.Entities;
using Product = Products.Api.Entities.Product;
using Products.Api.Entities.Dto.Product;
using Microsoft.AspNetCore.Authorization;

namespace Products.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddproductRequest req)
        {
            var product = _mapper.Map<Product>(req);
            var response = await _productService.AddProduct(product);
            if (!response.Success)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _productService.DeleteProduct(id);
            if (!response.Success)
            {
                return response.Message == "Product not found" ? NotFound(response) : StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productService.GetAllProducts();
            if (!response.Success)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
            return Ok(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetProducts(string name, int? minPrice, int? maxPrice)
        {
            var response = await _productService.GetProducts(name, minPrice, maxPrice);
            if (!response.Success)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Entities.Dto.Product.UpdateProductRequest req)
        {
            var product = _mapper.Map<Product>(req);
            var response = await _productService.UpdateProduct(id, product);
            if (!response.Success)
            {
                return response.Message == "Product not found" ? NotFound(response) : StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
            return Ok(response);
        }
    }
}
