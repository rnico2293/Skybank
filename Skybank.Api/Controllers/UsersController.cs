using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            // This method is not implemented in the IUserService interface.
            // You would need to implement a method in the service and repository to retrieve all users.
            //return Ok(new
            //{
            //    Message = "GetAll method is not implemented yet."
            //});
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }


        [HttpGet("by-email")]
        public async Task<IActionResult> GetByEmail (string email)
        {
            
            var user = await _userService.GetByEmailAsync(email);
            return Ok(user);
        }

    } 
}
