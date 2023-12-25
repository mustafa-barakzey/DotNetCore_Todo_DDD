using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace brk.Framework.Base.Application
{
    public interface ICommandDispatcher
    {
        Task<OperationResult> DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
        Task<OperationResult<TOut>> DispatchAsync<TCommand, TOut>(TCommand command) where TCommand : class, ICommand<TOut>;
    }

    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<CommandDispatcher> _logger;
        private readonly Stopwatch _stopwatch;

        public CommandDispatcher(ILogger<CommandDispatcher> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _stopwatch = new Stopwatch();
        }

        public async Task<OperationResult> DispatchAsync<TCommand>(TCommand command) where TCommand :class, ICommand
        {
            _stopwatch.Start();
            try
            {
                _logger.LogDebug("Routing command of type {CommandType} With value {Command}  Start at {StartDateTime}", command.GetType(), command, DateTime.Now);
                var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();

                return await handler.ExecuteAsync(command);

            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "There is not suitable handler for {CommandType} Routing failed at {StartDateTime}.", command.GetType(), DateTime.Now);
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation("Processing the {CommandType} command tooks {Millisecconds} Millisecconds", command.GetType(), _stopwatch.ElapsedMilliseconds);
            }

        }

        public async Task<OperationResult<TOut>> DispatchAsync<TCommand, TOut>(TCommand command) where TCommand :class, ICommand<TOut>
        {
            _stopwatch.Start();
            try
            {
                _logger.LogDebug("Routing command of type {CommandType} With value {Command}  Start at {StartDateTime}", command.GetType(), command, DateTime.Now);
                var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand, TOut>>();
                return await handler.ExecuteAsync(command);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There is not suitable handler for {CommandType} Routing failed at {StartDateTime}.", command.GetType(), DateTime.Now);
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation("Processing the {CommandType} command tooks {Millisecconds} Millisecconds", command.GetType(), _stopwatch.ElapsedMilliseconds);
            }
        }
    }
}
