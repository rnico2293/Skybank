using Microsoft.AspNetCore.Mvc;
using Skybank.Application.DTOs.User;
using Skybank.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Skybank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDTO request)
        {
            var userId = await _userService.RegisterAsync(request);

            return Ok(new
            {
                Id = userId,
                Message = "Usuario registrado correctamente"
            });
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> Delete(string email)
        {
            var userId = await _userService.DeleteAsync(email);

            return Ok(new
            {
                Message = "Usuario borrado correctamente"
            });
        }
        
    }
}
