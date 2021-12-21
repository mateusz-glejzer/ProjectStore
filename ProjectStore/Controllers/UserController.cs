using Microsoft.AspNetCore.Mvc;
using ProjectStore.Models;
using ProjectStore.Services;

namespace ProjectStore.Controllers
{
    [Route("user")] 
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody]RegisterUserDto dto)
        {
            _userService.RegisterUser(dto);
            return Ok();
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            string token = _userService.GenerateJwt(dto);
            return Ok(token);
        }

    }

   
}
