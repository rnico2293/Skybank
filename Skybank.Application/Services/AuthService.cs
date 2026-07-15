using Skybank.Application.DTOs.Login;
using Skybank.Application.Interfaces;
using Skybank.Domain.Entities;
using Skybank.Domain.Interfaces;

namespace Skybank.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasherService _passwordHasherService;
        private readonly IJwtTokenService _jwtTokenService;
        public AuthService(IUserRepository userRepository, IPasswordHasherService passwordHasherService, IJwtTokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasherService = passwordHasherService;
            _jwtTokenService = tokenService;
        }

        public async Task<LoginResponseDTO> LoginAsync(RequestLoginDTO loginUserDTO)
        {
              
            var user = await _userRepository.GetByEmailAsync(loginUserDTO.Email);

            if (user == null)
                throw new Exception("Incorrect credentials");

            bool isValidPassword = _passwordHasherService.VerifyPassword(loginUserDTO.Password,user.PasswordHash); 

            if (!isValidPassword)
                throw new Exception("Invalid credentials");

            var token = _jwtTokenService.GenerateToken(user);

            return new LoginResponseDTO
            {
                Token = token,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
   
    }
}