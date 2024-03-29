﻿using brk.Core.Domain.User.Commands;
using brk.Core.Domain.User.Query;
using brk.Endpoints.WebApi.Services.JWT;
using brk.Framework.Base.Application;

namespace brk.Endpoints.WebApi.Controllers.v1.User
{
    public class UserController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command) => await Create(command);

        [HttpPost]
        public async Task<IActionResult> LogIn(
            [FromServices] ICommandHandler<LogInUserCommand, LogInUserQueryResult> handler,
            [FromServices] IJwtManager jwtManager,
            [FromBody] LogInUserCommand command)
        {
            var result = await handler.ExecuteAsync(command);
            if (result.IsSuccess)
            {
                var token = jwtManager.GenerateToken(result.Data.UserId, result.Data.FullName);
                return Ok(token);
            }
            return BadRequest(result.Message);
        }
    }
}
