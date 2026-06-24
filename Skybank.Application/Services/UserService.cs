using Skybank.Application.DTOs;
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


        public async Task<Guid> RegisterAsync ( RegisterUserDTO request )
        {
            var existingUser = await _userRepository.EmailExistsAsync(request.Email);

            if (existingUser)
                throw new Exception("User already exists");

            var passwordHash = _passwordHasherService.HashPassword(request.Password); 

            var user = new User( request.Email,
                                 passwordHash,
                                 request.FirstName,
                                 request.LastName
            );

             await _userRepository.AddAsync(user);
             return user.Id;
        }
    }
}
