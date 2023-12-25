using brk.Framework.Tools.Exceptions;
using Microsoft.AspNetCore.Http;

namespace brk.Framework.Tools.Utils;

public class FileUploadOption
{
    public IFormFile File { get; private set; }
    public string OriginalPath { get; private set; }
    public string FileName { get; private set; }

    private FileUploadOption(IFormFile file, string originalPath, string? fileName = null)
    {
        if (file == null)
            throw new FileIsNullException();
        if (string.IsNullOrWhiteSpace(originalPath))
            throw new ArgumentNullException("مسیر فایل خالی میباشد");

        if (string.IsNullOrWhiteSpace(fileName))
            fileName = file.FileName;

        FileName = fileName;
        OriginalPath = originalPath;
        File = file;
    }

    public static FileUploadOption UploadImage(IFormFile file, string originalPath, string? fileName = null)
    {
        var option = new FileUploadOption(file, originalPath,fileName);
        if (file.IsImage())
            throw new FileIsNotImageException();
        return option;
    }

}