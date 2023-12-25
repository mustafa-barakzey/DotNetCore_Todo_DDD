namespace brk.Framework.Base.Application
{
    public interface ICommandHandler<T> where T :class, ICommand
    {
        Task<OperationResult> ExecuteAsync(T command);
    }

    public interface ICommandHandler<T,TU> where T : class, ICommand<TU>
    {
        Task<OperationResult<TU>> ExecuteAsync(T command);
    }
}
