namespace brk.Framework.Base.Exceptions
{
    /// <summary>
    /// کلاس پایه برای تمامی خطاهای هندل نشده در تمام پروژه
    /// </summary>
    public abstract class BaseAppException : Exception
    {
        public BaseAppException()
        {
            
        }

        public BaseAppException(string message):base(message)
        {
            
        }
    }
}
