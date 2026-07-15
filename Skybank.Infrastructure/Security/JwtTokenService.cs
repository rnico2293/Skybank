using Skybank.Application.Interfaces;
using Skybank.Domain.Entities;
using Skybank.Infrastructure.Configurations;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace Skybank.Application.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtOptions _jwtOptions;
        public JwtTokenService(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
        }


        public string GenerateToken(User user)
        {

            // Clave secreta
            var secretKey = _jwtOptions.Key;

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey));

            // Credenciales de firma
            var signingCredentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256);

            // Claims
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            // Crear el token
            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationInMinutes),
                signingCredentials: signingCredentials
            );

            // Retornar el JWT serializado
            return new JwtSecurityTokenHandler().WriteToken(token);


        }

    }
}
