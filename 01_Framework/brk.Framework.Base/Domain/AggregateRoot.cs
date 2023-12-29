namespace brk.Framework.Base.Domain
{
    public abstract class AggregateRoot<TId> : Entity<TId>
    {
    }

    public abstract class AggregateRoot : Entity<long>
    {
    }
}
