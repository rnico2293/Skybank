using Skybank.Domain.Entities;

namespace Skybank.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> EmailExistsAsync(string email);
        Task AddAsync(User user);

    }
}