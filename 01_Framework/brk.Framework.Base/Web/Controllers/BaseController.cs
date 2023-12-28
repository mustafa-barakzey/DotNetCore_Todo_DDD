using brk.Framework.Base.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace brk.Framework.Base.Web.Controllers
{
    public abstract class BaseController:Controller
    {
        private ICommandDispatcher CommandDispatcher => HttpContext.RequestServices.GetRequiredService<ICommandDispatcher>();

        public BaseController()
        {
        }

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
    }
}
