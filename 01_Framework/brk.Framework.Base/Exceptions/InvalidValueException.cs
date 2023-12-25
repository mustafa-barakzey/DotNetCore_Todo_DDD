namespace brk.Framework.Base.Exceptions
{
    /// <summary>
    /// درصورتی که مقدار وارد شده معتبر نباشد 
    /// </summary>
    public class InvalidValueException : BaseAppException
    {
        public InvalidValueException(string message):base(message)
        {
            
        }
    }
}
