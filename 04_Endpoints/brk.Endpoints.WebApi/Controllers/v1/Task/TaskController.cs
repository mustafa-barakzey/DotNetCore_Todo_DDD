using brk.Core.Domain.TaskList.Commands;
using Microsoft.AspNetCore.Authorization;

namespace brk.Endpoints.WebApi.Controllers.v1.TaskList
{
    [Authorize]
    public class TaskController:BaseApiController
    {
        /// <summary>
        /// اضافه کردن تسک به لیست
        /// </summary>
        /// <param name="command">اطلاعات تسک</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddTaskCommand command) =>await Create(command);
        /// <summary>
        /// اضافه کردن تسک به لیست
        /// </summary>
        /// <param name="command">اطلاعات تسک</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AddTaskCommand command) =>await Create(command);
    }
}
