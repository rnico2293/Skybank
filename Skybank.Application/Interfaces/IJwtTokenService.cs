using Skybank.Domain.Entities;

namespace Skybank.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}

