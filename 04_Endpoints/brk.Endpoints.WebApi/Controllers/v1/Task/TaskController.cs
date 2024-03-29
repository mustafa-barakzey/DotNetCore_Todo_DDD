﻿using brk.Core.Domain.TaskList.Commands;
using brk.Core.Domain.TaskList.Query;
using Microsoft.AspNetCore.Authorization;

namespace brk.Endpoints.WebApi.Controllers.v1.TaskList
{
    [Authorize]
    public class TaskController:BaseApiController
    {
        #region query

        /// <summary>
        /// get all tasks by list id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllTasks query) => await Query<GetAllTasks, AllTaskData>(query);

        /// <summary>
        /// get task detail
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDetail([FromQuery]GetTaskDetail query) => await Query<GetTaskDetail, TaskDetailData>(query);

        #endregion

        #region command

        /// <summary>
        /// add new task
        /// </summary>
        /// <param name="command">task detail</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddTaskCommand command) => await Create(command);

        /// <summary>
        /// edit task
        /// </summary>
        /// <param name="command">task detail</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] AddTaskCommand command) => await Create(command);

        #endregion
    }
}
