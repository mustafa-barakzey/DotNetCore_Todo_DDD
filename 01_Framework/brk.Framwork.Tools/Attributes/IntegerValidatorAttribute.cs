using System.ComponentModel.DataAnnotations;

namespace brk.Framework.Tools.Attributes
{
    /// <summary>
    /// این کلاس برای ولیدیشن پراپرتی هایی که از نوع عدد هستند ساخته شده
    /// </summary>
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.All)]
    public sealed class IntegerValidatorAttribute :ValidationAttribute
    {
        public int Min { get; set; } = 1;
        public int Max { get; set; } = int.MaxValue;
        public override bool IsValid(object? value)
        {
            if(value == null || value.GetType() != typeof(int))
                return false;
            var val=(int)value;
            return val >= Min && val <= Max;
        }
    }
}
