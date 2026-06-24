using Microsoft.EntityFrameworkCore;
using Skybank.Domain.Entities;
using Skybank.Domain.Interfaces;
using Skybank.Infrastructure.Persistence;

namespace Skybank.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SkyBankDbContext _context;

        public UserRepository(SkyBankDbContext context)
        {
             _context = context; 
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users
                .AnyAsync(x => x.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(); 
        }

    }
}
