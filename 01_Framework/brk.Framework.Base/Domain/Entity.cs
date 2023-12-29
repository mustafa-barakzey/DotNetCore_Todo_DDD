namespace brk.Framework.Base.Domain
{
    public abstract class Entity<TId>
    {
        public TId Id { get; set; }
    }

    public abstract class Entity: Entity<long>
    {
    }
}