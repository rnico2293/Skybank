using Skybank.Application.DTOs;


namespace Skybank.Application.Interfaces
{
    public interface IUserService
    {
        Task<Guid> RegisterAsync(RegisterUserDTO userDTO);
    }
}
