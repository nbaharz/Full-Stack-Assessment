using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAutomationAPI.Entities;
using StudentAutomationAPI.Services;
using StudentAutomationAPI.DTO;
using StudentAutomationAPI.Services.Interfaces;

namespace StudentAutomationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UsersController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();

            // UserDto map
            var result = users.Select(u => new UserDto
            {
                Email = u.Email,
                FullName = u.FullName,
                Role = u.Role
            });

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();

            var result = new UserDto
            {
                Email = user.Email,
                FullName = user.FullName,
                Role = user.Role
            };

            return Ok(result);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var created = await _userService.RegisterAsync(dto);
            var token = _tokenService.GenerateToken(created);
            return Ok(new { token });
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userService.LoginAsync(dto.Email, dto.Password);
            if (user == null) return Unauthorized();
            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }
    }

    
}
