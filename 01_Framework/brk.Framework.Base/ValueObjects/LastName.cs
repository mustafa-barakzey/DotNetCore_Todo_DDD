using brk.Framework.Base.Exceptions;

namespace brk.Framework.Base.ValueObjects
{
    public class LastName : BaseValueObject<LastName>
    {
        public string Value;

        public LastName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidValueException("نام خانوادگی اجباری میباشد");

            Value = value;
        }

        public override bool ObjectIsEqual(LastName otherObject) => otherObject.Value == Value;

        public override int ObjectGetHashCode() => Value.GetHashCode();

        public static LastName FromString(string value) => new(value);
    }
}
