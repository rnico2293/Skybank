using Skybank.Application.DTOs.User;
using Skybank.Application.Interfaces;
using Skybank.Domain.Entities;
using Skybank.Domain.Interfaces;

namespace Skybank.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasherService _passwordHasherService;

        public UserService(IUserRepository userRepository, IPasswordHasherService passwordHasherService)
        {
            _userRepository = userRepository;
            _passwordHasherService = passwordHasherService;
        }


        public async Task<Guid> RegisterAsync(RegisterUserDTO request)
        {
            var existingUser = await _userRepository.EmailExistsAsync(request.Email);

            if (existingUser)
                throw new Exception("User already exists");

            var passwordHash = _passwordHasherService.HashPassword(request.Password);

            var user = new User(request.Email,
                                 passwordHash,
                                 request.FirstName,
                                 request.LastName
            );

            await _userRepository.AddAsync(user);
            return user.Id;
        }

        public async Task<Guid> DeleteAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                throw new Exception("User not found");
            await _userRepository.DeleteAsync(user);
            return user.Id;
        }

        public async Task<List<GetUserDTO>> GetAllAsync()
        {
            // This method is not implemented in the IUserRepository interface.
            // You would need to implement a method in the repository to retrieve all users.

            var users = await _userRepository.GetAllAsync();
            var userDTOs = users.Select(user => new GetUserDTO(
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.CreatedAt
            )).ToList();

            return userDTOs;
        }
        public async Task<GetUserDTO> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                throw new Exception("User not found");
            GetUserDTO userDto = new GetUserDTO(
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.CreatedAt
            );
            return userDto;
        }
    }
}