namespace brk.Framework.Tools.Constants
{
    public class RegexPattern
    {
        /// <summary>
        /// پترن ولیدیشن برای موبایل
        /// </summary>
        public const string MobilePattern = @"(\+989|00989|989|09|\+۹۸۹|۰۰۹۸۹|۹۸۹|۰۹)[0-9,۰,١,۲,۳,۴,۵,۶,۷,۸,۹]{9,9}$";

        /// <summary>
        /// پترن ولیدیشن برای ایمیل
        /// </summary>
        public const string EmailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
    }
}
