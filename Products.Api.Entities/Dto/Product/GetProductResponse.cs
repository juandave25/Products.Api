using Products.Api.Entities.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Api.Entities.Dto.Product
{
    public class GetProductResponse
    {
        public ApiResponse<List<Entities.Product>> Response {get; set;}
    }
}
