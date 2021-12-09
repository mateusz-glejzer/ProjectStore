using Microsoft.AspNetCore.Mvc;
using ProjectStore.Models;
using ProjectStore.Services;

namespace ProjectStore.Controllers
{
    [Route("user")] 
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _accountService;

        public UserController(IUserService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody]RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
           // string token = _userService.GenerateJwt(dto);
            return Ok();
        }

    }

   
}
