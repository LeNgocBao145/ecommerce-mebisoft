using AuthService.Application.DTOs;
using AuthService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController(IUserService userService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginRequestDTO loginRequestDTO)
        {
            // Implementation for user login
            var result = await userService.Login(loginRequestDTO);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserResponseDTO>> Register(UserRequestDTO userRequestDTO)
        {
            // Implementation for user registration
            var result = await userService.Register(userRequestDTO);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
