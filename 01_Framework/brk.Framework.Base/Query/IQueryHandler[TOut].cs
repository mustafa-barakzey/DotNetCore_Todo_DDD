using brk.Framework.Base.Application;

namespace brk.Framework.Base.Query
{
    public interface IQueryHandler<TOut> where TOut : class, IQueryResult
    {
        Task<OperationResult<TOut>> HandleAsync();
    }

    public abstract class BaseQueryHandler<TOut> : IQueryHandler<TOut> where TOut : class, IQueryResult
    {
        public BaseQueryHandler()
        {
        }

        public abstract Task<OperationResult<TOut>> HandleAsync();

        public OperationResult<TOut> Ok(string message, TOut data) => OperationResult<TOut>.Success(data, message);
        public OperationResult<TOut> Info(string message) => OperationResult<TOut>.Info(message);
        public OperationResult<TOut> Warning(string message) => OperationResult<TOut>.Warning(message);
        public OperationResult<TOut> Error(string message) => OperationResult<TOut>.Error(message);
    }
}
