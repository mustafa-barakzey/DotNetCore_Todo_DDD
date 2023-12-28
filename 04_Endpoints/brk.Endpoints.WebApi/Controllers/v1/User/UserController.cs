using brk.Core.Domain.User.Commands;
using brk.Endpoints.WebApi.Controllers.v1.Base;
using Microsoft.AspNetCore.Mvc;

namespace brk.Endpoints.WebApi.Controllers.v1.User
{
    public class UserController : BaseApiController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command) => await Create(command);
    }
}
