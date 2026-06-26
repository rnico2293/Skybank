using Skybank.Application.DTOs.User;


namespace Skybank.Application.Interfaces
{
    public interface IUserService
    {
        Task<Guid> RegisterAsync(RegisterUserDTO userDTO);
        Task<Guid> DeleteAsync (string email);
        Task<List<GetUserDTO>> GetAllAsync();   

        Task<GetUserDTO> GetByEmailAsync(string email); 
    }
}
