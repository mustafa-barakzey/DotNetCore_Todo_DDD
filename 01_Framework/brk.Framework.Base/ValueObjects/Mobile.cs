using brk.Framework.Base.Exceptions;
using brk.Framework.Base.Utils;

namespace brk.Framework.Base.ValueObjects
{
    public class Mobile : BaseValueObject<Mobile>
    {
        public string Value { get; private set; }
        public Mobile(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new InvalidValueException("شماره موبایل اجباری میباشد");
            if (!value.IsMobileNumberValid())
                throw new InvalidValueException("شماره موبایل وارد شده نادرست میباشد");

            Value = value.ToFormatMobile();
        }
        public static Mobile FromString(string value) => new(value);
        public override int ObjectGetHashCode() => Value.GetHashCode();

        public override bool ObjectIsEqual(Mobile otherObject) => otherObject.Value == Value;
        public static implicit operator string(Mobile value) => value.Value;
        public static implicit operator Mobile(string value) => new(value);
    }
}
