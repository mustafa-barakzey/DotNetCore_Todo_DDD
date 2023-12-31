using brk.Core.Domain.List.Commands;
using Microsoft.AspNetCore.Authorization;

namespace brk.Endpoints.WebApi.Controllers.v1.List
{
    [Authorize]
    public class ListController:BaseApiController
    {
        /// <summary>
        /// اضافه کردن لیست جدید
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("AddList")]
        public async Task<IActionResult> Add([FromBody] AddListCommand command) =>await Create(command);
    }
}
