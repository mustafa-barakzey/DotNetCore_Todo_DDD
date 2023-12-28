using brk.Framework.Base.Exceptions;
using brk.Framework.Base.ValueObjects;

namespace brk.Core.Domain.User.ValueObjects
{
    public class Password : BaseValueObject<Password>
    {
        public string Value;
        private Password(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new InvalidValueException("کلمه عبور اجباری میباشد");
            if (value.Length < 6)
                throw new InvalidValueException("کلمه عبور حداقل باید 6 کاراکتر باشد");

            Value = value;
        }

        public static Password FromString(string pass) => new(pass);

        public override int ObjectGetHashCode() => Value.GetHashCode();

        public override bool ObjectIsEqual(Password otherObject) => otherObject.Value == Value;
    }
}
