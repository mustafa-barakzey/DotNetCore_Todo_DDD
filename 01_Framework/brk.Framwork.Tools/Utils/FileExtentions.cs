using brk.Framework.Tools.Constants;
using Microsoft.AspNetCore.Http;

namespace brk.Framework.Tools.Utils
{
    /// <summary>
    /// آپلود عکس
    /// </summary>
    public static class FileExtentions
    {
        /// <summary>
        /// چک میکند آیا فایل از نوع تصویر هست یا خیر
        /// </summary>
        /// <param name="file">فایل</param>
        /// <returns></returns>
        public static bool IsImage(this IFormFile file)
        {
            var imageExtentions = new[] { ".jpg", ".jpeg", ".png" };
            var fileExtention = Path.GetExtension(file.Name).ToLower();
            return imageExtentions.Any(m => fileExtention == m);
        }

        /// <summary>
        /// آپلود عکس
        /// </summary>
        public static void Upload(FileUploadOption option)
        {
            var originalPath = GetDirectoryPath(option.OriginalPath);
            var fileName = option.FileName;
            var image = option.File;

            var filePath = Path.Combine(originalPath, fileName);

            // چک میکند از قبل این مسیر وجود دارد یا خیر
            //  درصورت عدم وجود آن را ایجاد میکنیم
            if (!Directory.Exists(originalPath))
                Directory.CreateDirectory(originalPath);

            // درصورت وجود فایل آن را حذف میکنیم    
            // و فایل جدید رو آپلود میکنیم
            if (File.Exists(filePath))
                File.Delete(filePath);

            using var stream = new FileStream(filePath, FileMode.Create);

            if (!Directory.Exists(originalPath))
                image.CopyTo(stream);
        }

        public static void DeleteByUrl(string url)
        {
            if(string.IsNullOrWhiteSpace(url))
                return; 

            var filePath = url.Replace($"{MainConstant.ApiBaseUrl}/", "");

            if (File.Exists(filePath))
                File.Delete(filePath);

            //var directory = Path.GetDirectoryName(filePath);

            //while (!string.IsNullOrWhiteSpace(directory))
            //{
            //    if (Directory.GetFiles(directory).Any()) break;

            //    Directory.Delete(directory);
            //    directory=Path.GetDirectoryName(directory);
            //}
        }
        public static void DeleteByFileName(string path, string fileName)
        {
            if (string.IsNullOrEmpty(path) ||
                string.IsNullOrEmpty(fileName))
                return;

            var filePath = Path.Combine(path, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(path);
            }
        }

        public static List<string> GetFiles(string filePath)
        {
            var directory = GetDirectoryPath(filePath);
            if (Directory.Exists(directory))
            {
                return Directory.GetFiles(directory)
                        .Select(file => $"{GetDirectoryUri(filePath)}/{Path.GetFileName(file)}")
                        .ToList();
            }

            return new();
        }

        private static string GetDirectoryUri(string filePath) => MainConstant.ApiBaseUrl + "/" + filePath.Replace("\\", "/");

        private static string GetDirectoryPath(string directory) => Path.Combine(MainConstant.ApiContentRoot, directory);
    }
}
