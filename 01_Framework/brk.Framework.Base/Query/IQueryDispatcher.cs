using brk.Framework.Base.Application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace brk.Framework.Base.Query
{
    public interface IQueryDispatcher
    {
        Task<OperationResult<TOut>> DispatchAsync<TOut>() where TOut : class, IQueryResult;
        Task<OperationResult<TOut>> DispatchAsync<TQuery, TOut>(TQuery query) where TOut : class, IQueryResult where TQuery : class, IQuery;
    }

    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<QueryDispatcher> _logger;
        private readonly Stopwatch _stopwatch;

        public QueryDispatcher(ILogger<QueryDispatcher> logger, IServiceProvider serviceProvider)
        {
            _stopwatch = new();
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task<OperationResult<TOut>> DispatchAsync<TOut>() where TOut : class,IQueryResult
        {
            _stopwatch.Start();
            try
            {
                _logger.LogDebug("start query dispatcher with result type {QueryType} Start at {StartDateTime}", typeof(TOut), DateTime.Now);

                var handler = _serviceProvider.GetRequiredService<IQueryHandler<TOut>>();

                return await handler.HandleAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "query dispatcher with result type {resultType} {StartDateTime} failed.", typeof(TOut), DateTime.Now);
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation("Processing the query with result type {resultType} tooks {Milliseconds} Milliseconds", typeof(TOut), _stopwatch.ElapsedMilliseconds);
            }
        }

        public async Task<OperationResult<TOut>> DispatchAsync<TQuery, TOut>(TQuery query) where TOut : class, IQueryResult where TQuery : class, IQuery
        {
            _stopwatch.Start();
            try
            {
                _logger.LogDebug("start query dispatcher with result type {resultType} Start at {StartDateTime}", typeof(TOut), DateTime.Now);

                var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TOut>>();
                return await handler.HandleAsync(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "query dispatcher with result type {resultType} {StartDateTime} failed.", typeof(TOut), DateTime.Now);
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation("Processing the query with result type {resultType} tooks {Milliseconds} Milliseconds", typeof(TOut), _stopwatch.ElapsedMilliseconds);
            }
        }
    }
}
