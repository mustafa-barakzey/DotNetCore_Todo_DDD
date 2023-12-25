using System.Text.RegularExpressions;

namespace brk.Framework.Tools.Utils
{
    public static class TextFixer
    {
        /// <summary>
        /// خالی کردن متن از فضای خالی
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string FixText(this string text) => text?.Trim().Replace("  ", " ");

        /// <summary>
        /// کوچک کردن و خالی کردن از فضای خالی ایمیل
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static string FixEmail(this string email) => email.Trim().ToLower().Replace(" ", "");

        public static string RemoveHtmlTagsExceptBreak(this string text) => Regex.Replace(text, @"<(?!br[\x20/>])[^<>]+>", string.Empty);

        /// <summary>
        /// تبدیل متن برای نمایش در ادرس (جایگزین کردن فضای خالی با منها)ه
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string FixTextForUrl(this string text)
        {
            return text.Replace(" ", "-");
        }

        /// <summary>
        /// جایگزین , برای نمایش هشتگ ها
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public static string[] SplitTagsWithComma(this string tags)
        {
            return tags.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public static string[] SplitTagsWithDash(this string tags)
        {
            return tags.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
