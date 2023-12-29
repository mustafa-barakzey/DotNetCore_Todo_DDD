using brk.Framework.Base.Exceptions;

namespace brk.Framework.Base.ValueObjects
{
    public class Title : BaseValueObject<Title>
    {
        public string Value;

        public Title(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new InvalidValueException("عنوان اجباری میباشد");
            Value = value;
        }

        public static Title FromString(string value) => new(value);

        public override int ObjectGetHashCode()=>Value.GetHashCode();

        public override bool ObjectIsEqual(Title otherObject)=>otherObject.Value==Value;
    }
}
