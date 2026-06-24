using Microsoft.AspNetCore.Identity;
using Skybank.Application.Interfaces; 

namespace Skybank.Infrastructure.Security
{
    public class PasswordHasherService : IPasswordHasherService
    {
        private readonly PasswordHasher<object> _passwordHasher;

        public PasswordHasherService()
        {
            _passwordHasher = new PasswordHasher<object>();
        }

        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(
                new object(),
                password);
        }
    }
}
