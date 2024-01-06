using brk.Core.Domain.List.Commands;
using brk.Core.Domain.List.Query;
using Microsoft.AspNetCore.Authorization;

namespace brk.Endpoints.WebApi.Controllers.v1.List
{
    [Authorize]
    public class ListController:BaseApiController
    {
        #region query

        /// <summary>
        /// get all user list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get() => await Query<GetUserList>();

        /// <summary>
        /// get list detail by id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] GetUserListDetailQuery query) => await Query<GetUserListDetailQuery,GetUserListDetail>(query);

        #endregion

        #region command

        /// <summary>
        /// add new list
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddListCommand command) => await Create(command);

        /// <summary>
        /// add new list
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditListCommand command) => await Edit(command);

        /// <summary>
        /// add new list
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteListCommand command) => await Delete(command);

        #endregion
    }
}
