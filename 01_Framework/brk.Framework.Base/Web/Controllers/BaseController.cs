using brk.Framework.Base.Application;
using brk.Framework.Base.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace brk.Framework.Base.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private ICommandDispatcher CommandDispatcher => HttpContext.RequestServices.GetRequiredService<ICommandDispatcher>();

        private IQueryDispatcher QueryDispatcher => HttpContext.RequestServices.GetRequiredService<IQueryDispatcher>();

        public BaseController()
        {
        }

        #region command
        protected async Task<IActionResult> Create<TCommand, TCommandResult>(TCommand command) where TCommand : class, ICommand<TCommandResult>
        {
            var result = await CommandDispatcher.DispatchAsync<TCommand, TCommandResult>(command);
            if (result.StatusCode == OperationResultStatusCode.Success)
            {
                return StatusCode((int)HttpStatusCode.Created, result.Data);
            }
            return BadRequest(result.Message);
        }

        protected async Task<IActionResult> Create<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            var result = await CommandDispatcher.DispatchAsync(command);
            if (result.StatusCode == OperationResultStatusCode.Success)
            {
                return StatusCode((int)HttpStatusCode.Created);
            }
            return BadRequest(result.Message);
        }


        protected async Task<IActionResult> Edit<TCommand, TCommandResult>(TCommand command) where TCommand : class, ICommand<TCommandResult>
        {
            var result = await CommandDispatcher.DispatchAsync<TCommand, TCommandResult>(command);
            if (result.StatusCode == OperationResultStatusCode.Success)
            {
                return StatusCode((int)HttpStatusCode.OK, result.Data);
            }
            else if (result.StatusCode == OperationResultStatusCode.NotFound)
            {
                return StatusCode((int)HttpStatusCode.NotFound, command);
            }
            return BadRequest(result.Message);
        }

        protected async Task<IActionResult> Edit<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            var result = await CommandDispatcher.DispatchAsync(command);
            if (result.StatusCode == OperationResultStatusCode.Success)
            {
                return StatusCode((int)HttpStatusCode.OK);
            }
            else if (result.StatusCode == OperationResultStatusCode.NotFound)
            {
                return StatusCode((int)HttpStatusCode.NotFound, command);
            }
            return BadRequest(result.Message);
        }


        protected async Task<IActionResult> Delete<TCommand, TCommandResult>(TCommand command) where TCommand : class, ICommand<TCommandResult>
        {
            var result = await CommandDispatcher.DispatchAsync<TCommand, TCommandResult>(command);
            if (result.StatusCode == OperationResultStatusCode.Success)
            {
                return StatusCode((int)HttpStatusCode.OK, result.Data);
            }
            else if (result.StatusCode == OperationResultStatusCode.NotFound)
            {
                return StatusCode((int)HttpStatusCode.NotFound, command);
            }
            return BadRequest(result.Message);
        }

        protected async Task<IActionResult> Delete<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            var result = await CommandDispatcher.DispatchAsync(command);
            if (result.StatusCode == OperationResultStatusCode.Success)
            {
                return StatusCode((int)HttpStatusCode.OK);
            }
            else if (result.StatusCode == OperationResultStatusCode.NotFound)
            {
                return StatusCode((int)HttpStatusCode.NotFound, command);
            }
            return BadRequest(result.Message);
        }

        #endregion

        #region query
        public async Task<IActionResult> Query<TOut>() where TOut : class, IQueryResult
        {
            var result = await QueryDispatcher.DispatchAsync<TOut>();
            if (result.StatusCode == OperationResultStatusCode.Success)
            {
                return StatusCode((int)HttpStatusCode.OK,result);
            }
            else if (result.StatusCode == OperationResultStatusCode.NotFound)
            {
                return StatusCode((int)HttpStatusCode.NotFound, result);
            }
            return BadRequest(result.Message);
        }

        public async Task<IActionResult> Query<TQuery,TOut>(TQuery query) where TOut : class, IQueryResult<TQuery> where TQuery : class, IQuery
        {
            var result = await QueryDispatcher.DispatchAsync<TQuery,TOut>(query);
            if (result.StatusCode == OperationResultStatusCode.Success)
            {
                return StatusCode((int)HttpStatusCode.OK, result);
            }
            else if (result.StatusCode == OperationResultStatusCode.NotFound)
            {
                return StatusCode((int)HttpStatusCode.NotFound, result);
            }
            return BadRequest(result.Message);
        }

        #endregion
    }
}
