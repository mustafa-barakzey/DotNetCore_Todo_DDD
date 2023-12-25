using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace brk.Framework.Tools.Attributes
{
    public class ListValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value == null)
                return false;
            var list = (ICollection) value;
            return list.Count != 0;
        }
    }
}
