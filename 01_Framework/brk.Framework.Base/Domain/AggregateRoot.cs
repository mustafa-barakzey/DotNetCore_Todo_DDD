namespace brk.Framework.Base.Domain
{
    public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
    {
    }

    public abstract class AggregateRoot : Entity<long>, IAggregateRoot
    {
    }

    public interface IAggregateRoot
    {

    }
}
