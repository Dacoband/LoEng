using LoEng.Server.Application.Commands.User;
using LoEng.Server.Application.DTOs.User;
using LoEng.Server.Application.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoEng.Server.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetAllUserQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDTO userCreateDto)
        {
            var command = new CreateUserCommand { UserCreateDTO = userCreateDto };
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAllUsers), result);
        }
    }
}
