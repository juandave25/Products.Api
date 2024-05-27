using Products.Api.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Api.Entities.Dto.Product
{
    public class UpdateProductResponse
    {
        public ApiResponse<Entities.Product> Response { get; set; }
    }
}
