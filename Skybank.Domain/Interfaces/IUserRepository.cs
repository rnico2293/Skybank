using Skybank.Domain.Entities;

namespace Skybank.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> EmailExistsAsync(string email);
        Task AddAsync(User user);
        Task<User?> GetByEmailAsync(string email);
        Task DeleteAsync(User user);
        Task<List<User>> GetAllAsync();
    }
}