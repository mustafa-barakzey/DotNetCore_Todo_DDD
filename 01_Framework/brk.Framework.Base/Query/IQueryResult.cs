namespace brk.Framework.Base.Query
{
    public interface IQueryResult
    {
    }

    public interface IQueryResult<TQuery> where TQuery : IQuery
    {
    }
}
