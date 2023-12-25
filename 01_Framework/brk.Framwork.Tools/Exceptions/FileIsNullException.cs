namespace brk.Framework.Tools.Exceptions;

public class FileIsNullException : Exception
{
    public FileIsNullException() : base("فایلی برای آپلود یافت نشد")
    {
    }
}