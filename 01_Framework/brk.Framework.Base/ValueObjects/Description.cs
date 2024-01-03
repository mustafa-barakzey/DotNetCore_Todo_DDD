using brk.Framework.Base.Exceptions;

namespace brk.Framework.Base.ValueObjects
{
    public class Description : BaseValueObject<Description>
    {
        public string Value;

        public Description(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new InvalidValueException("توضیحات نمیتواند خالی باشد");
            Value = value;
        }

        public static Description FromString(string value) => new(value);

        public override int ObjectGetHashCode() => Value.GetHashCode();

        public override bool ObjectIsEqual(Description otherObject) => otherObject.Value == Value;
    }
}
