using Azure.Core;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Skybank.Application.DTOs.Login;
using Skybank.Application.DTOs.User;
using Skybank.Application.Interfaces;

namespace Skybank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;  
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("login")]  

        public async Task<IActionResult> Login(RequestLoginDTO request)
        {
            var response = await _authService.LoginAsync(request);
            return Ok(response);
        }       

    }
}