using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Registration.BusinessLogicLayer.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator = default;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpPost]
        [Route("/api/User/RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand item)
        {
            var response = await _mediator.Send(item);
            return Ok(response);
        }

        [HttpPost]
        [Route("/api/User/LogIn")]
        public async Task<IActionResult> LogIn([FromBody] LogInCommand item)
        {
            var token = await _mediator.Send(item);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [HttpPut]
        [Authorize]
        [Route("/api/User/UpdateUserInfo/{id}")]
        public async Task<IActionResult> UpdateUserInfo(int id,[FromBody] UpdateUserInfoCommand item)
        {
            item.UserId = id;
            var response = await _mediator.Send(item);
            return Ok(response);
        }


        [Authorize]
        [HttpDelete]
        [Route("/api/User/DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await _mediator.Send(new DeleteUserCommand() { UserId = id});
            return Ok(response);
        }
    }
}
