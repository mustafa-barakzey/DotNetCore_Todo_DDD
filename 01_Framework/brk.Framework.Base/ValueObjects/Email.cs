using brk.Framework.Base.Exceptions;
using brk.Framework.Base.Utils;

namespace brk.Framework.Base.ValueObjects;

public class Email : BaseValueObject<Email>
{
    public string Value { get; set; }
    public Email(string value)
    {
        if (!string.IsNullOrEmpty(value) && !value.IsEmail())
            throw new InvalidValueException("ایمیل وارد شده نامعتبر میباشد");

        Value = value;
    }

    public override int ObjectGetHashCode() => Value.GetHashCode();

    public override bool ObjectIsEqual(Email otherObject) => otherObject.Value == Value;

    public static Email FromString(string email) => new(email);

    public static implicit operator string(Email email) => email.Value;
}
