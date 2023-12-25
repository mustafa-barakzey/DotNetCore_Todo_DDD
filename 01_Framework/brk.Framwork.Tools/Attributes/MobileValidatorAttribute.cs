using System.ComponentModel.DataAnnotations;
using brk.Framework.Tools.Extensions;

namespace brk.Framework.Tools.Attributes
{
    /// <summary>
    /// ولیدیشن شماره موبایل
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class MobileValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is not string val || string.IsNullOrWhiteSpace(val))
            {
                ErrorMessage ??= "شماره موبایل اجباری میباشد";
                return false;
            }
            if (!val.IsMobileNumberValid())
            {
                ErrorMessage = "شماره موبایل معتبر نمیباشد";
                return false;
            }
            return true;
        }
    }
}
