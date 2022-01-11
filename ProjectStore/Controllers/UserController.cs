using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectStore.Models;
using ProjectStore.Services;
using System.Threading.Tasks;
using ProjectStore.Commands;

namespace ProjectStore.Controllers
{
    [Route("user")] 
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpPost("register")]
        public async Task RegisterUser([FromBody]RegisterUserDto dto)
        {            
           await _mediator.Send(new RegisterUserCommand(dto));
        }


        [HttpPost("login")]
        public async Task<string> Login([FromBody] LoginDto dto)
        {
            
            return await _mediator.Send(new LoginUserCommand(dto));
        }

    }

   
}
