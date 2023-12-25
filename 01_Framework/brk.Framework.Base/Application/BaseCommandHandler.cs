
namespace brk.Framework.Base.Application
{
    public abstract class BaseCommandHandler<T> : ICommandHandler<T> where T : class, ICommand
    {
        public abstract Task<OperationResult> ExecuteAsync(T command);

        public OperationResult Ok(string message) => OperationResult.Success(message);
        public OperationResult Info(string message) => OperationResult.Info(message);
        public OperationResult Warning(string message) => OperationResult.Warning(message);
        public OperationResult Error(string message) => OperationResult.Error(message);
    }

    public abstract class BaseCommandHandler<T, TOut> : ICommandHandler<T, TOut> where T : class, ICommand<TOut>
    {
        public abstract Task<OperationResult<TOut>> ExecuteAsync(T command);

        public OperationResult<TOut> Ok(string message, TOut data) => OperationResult<TOut>.Success(data, message);
        public OperationResult<TOut> Info(string message) => OperationResult<TOut>.Info(message);
        public OperationResult<TOut> Warning(string message) => OperationResult<TOut>.Warning(message);
        public OperationResult<TOut> Error(string message) => OperationResult<TOut>.Error(message);
    }
}
