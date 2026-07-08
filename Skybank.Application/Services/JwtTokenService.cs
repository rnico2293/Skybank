using Skybank.Application.Interfaces;
using Skybank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skybank.Application.Services
{
    public class JwtTokenService : IJwtTokenService
    {

        public string GenerateToken(User user)
        {
            // Implement JWT token generation logic here
            // For example, you can use System.IdentityModel.Tokens.Jwt package to create a JWT token
            // This is a placeholder implementation and should be replaced with actual token generation logic
            var token = $"Token_For_User_{user.Id}";
            return token;   
        }

    }
}
