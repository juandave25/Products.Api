using Products.Api.Entities.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Api.Entities.Dto.Product
{
    public class AddProductResponse
    {
        public ApiResponse<Entities.Product> Response { get; set; }
    }
}
