using brk.Core.Application.User.Commands;
using brk.Core.Domain.User.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace brk.Endpoints.WebApi.Controllers.v1.User
{
    [Route("/api/[controller]")]
    public class UserController:ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromServices] RegisterUserCommandHandler handler, [FromBody]RegisterUserCommand command)
        {
            var result=await handler.ExecuteAsync(command);
            if (result.IsSuccess)
                return StatusCode((int)HttpStatusCode.Created,result);
            return BadRequest(result);
        }
    }
}
