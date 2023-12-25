using System.ComponentModel.DataAnnotations;

namespace brk.Framework.Tools.Attributes
{
    public class TimeValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return Validate(value);
        }

        private bool Validate(object? value)
        {
            var val = value as string;

            if (string.IsNullOrWhiteSpace(val))
                return false;
            var convertTimeResult = TimeSpan.TryParse(val, out var time);

            if (!convertTimeResult)
            {
                ErrorMessage = "امکان تبدیل زمان وجود ندارد . زمان باید با فرمت 00:00 ارسال شود";
                return false;
            }
            return true;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var result = Validate(value);
            if(result)
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage,new List<string>(){ validationContext.DisplayName });
        }
    }
}
