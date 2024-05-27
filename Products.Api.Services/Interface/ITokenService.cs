using Products.Api.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Api.Services.Interface
{
    public interface ITokenService
    {
        string GenerateToken(string userId, JwtConfig config);
    }
}
