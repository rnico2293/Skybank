using Microsoft.AspNetCore.Mvc;
using Skybank.Application.DTOs;
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




        // GET: api/<UsersController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

    }
}
