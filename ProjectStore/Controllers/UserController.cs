﻿using MediatR;
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
        public async Task<IActionResult> RegisterUser([FromBody]RegisterUserDto dto)
        {            
          return Ok(await _mediator.Send(new RegisterUserCommand(dto)));
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            
            return Ok(await _mediator.Send(new LoginUserCommand(dto)));
        }

    }

   
}
