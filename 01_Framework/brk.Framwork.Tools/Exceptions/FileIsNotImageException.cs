namespace brk.Framework.Tools.Exceptions;

public class FileIsNotImageException : Exception
{
    public FileIsNotImageException() : base("فایل آپلود شده باید از نوع تصویر باشد")
    {

    }
}