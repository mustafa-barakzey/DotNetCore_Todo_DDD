using brk.Framework.Base.Exceptions;

namespace brk.Framework.Base.ValueObjects
{
    public class FirstName : BaseValueObject<FirstName>
    {
        public string Value;

        public FirstName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidValueException("نام اجباری میباشد");

            Value = value;
        }

        public override bool ObjectIsEqual(FirstName otherObject) => otherObject.Value == Value;

        public override int ObjectGetHashCode() => Value.GetHashCode();

        public static FirstName FromString(string value) => new(value);
    }
}
