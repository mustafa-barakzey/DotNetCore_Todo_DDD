using brk.Framework.Base.Exceptions;
using brk.Framework.Base.ValueObjects;

namespace brk.Core.Domain.List.ValueObjects
{
    public class ListOwnerId : BaseValueObject<ListOwnerId>
    {
        public long Value;

        public ListOwnerId(long value)
        {
            if (value < 0)
                throw new InvalidValueException(nameof(ListOwnerId));
            Value = value;
        }

        public static ListOwnerId FromLong(long id) => new(id);
        public override int ObjectGetHashCode()=>Value.GetHashCode();

        public override bool ObjectIsEqual(ListOwnerId otherObject)=>otherObject.Value == Value;
    }
}
