﻿using brk.Framework.Base.Constants;
using System.Text.RegularExpressions;

namespace brk.Framework.Base.Utils
{
    internal static class StringValidations
    {
        public static bool IsMobileNumberValid(this string mobile) =>
       !string.IsNullOrWhiteSpace(mobile) && Regex.IsMatch(mobile, RegexPattern.MobilePattern);

        public static string ToFormatMobile(this string mobile)
        {
            if (string.IsNullOrEmpty(mobile))
                return string.Empty;
            var characters = new[] { "-", " ", ")", "(", "," };
            mobile = characters.Aggregate(mobile, (current, character) => current.Replace(character, string.Empty));
            mobile = mobile.ToEnglishNumber();
            return mobile.Length < 10
                ? string.Empty
                : $"+98{mobile.Substring(mobile.Length - 10, 10)}";
        }

        public static string ToEnglishNumber(this string text) =>
    text.Replace("۰", "0")
        .Replace("۱", "1")
        .Replace("۲", "2")
        .Replace("۳", "3")
        .Replace("۴", "4")
        .Replace("۵", "5")
        .Replace("۶", "6")
        .Replace("۷", "7")
        .Replace("۸", "8")
        .Replace("۹", "9");

        public static bool IsEmail(this string email)
        {
            Regex regex = new Regex(RegexPattern.EmailPattern);
            try
            {
                return regex.IsMatch(email);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool IsValidStaticPhone(this string phone)
        {
            try
            {
                if (string.IsNullOrEmpty(phone))
                    return false;
                var r = new Regex(@"^0[0-9]{2,}[0-9]{7,}$");
                return r.IsMatch(phone);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// صحت سنجی کد ملی
        /// </summary>
        /// <param name="input">کد ملی</param>
        /// <returns>درست یا غلط</returns>
        public static bool IsNationalCode(this string nationalCode)
        {
            if (string.IsNullOrWhiteSpace(nationalCode) || !nationalCode.IsLengthBetween(8, 10))
                return false;

            nationalCode = nationalCode.PadLeft(10, '0');

            if (!nationalCode.IsNumeric())
                return false;

            if (!IsFormat1Validate(nationalCode))
                return false;

            if (!IsFormat2Validate(nationalCode))
                return false;
            return true;

            static bool IsFormat1Validate(string nationalCode)
            {
                var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
                if (!allDigitEqual.Contains(nationalCode))
                    return true;
                return false;
            }

            static bool IsFormat2Validate(string nationalCode)
            {
                var chArray = nationalCode.ToCharArray();
                var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
                var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
                var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
                var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
                var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
                var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
                var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
                var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
                var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
                var a = Convert.ToInt32(chArray[9].ToString());

                var b = num0 + num2 + num3 + num4 + num5 + num6 + num7 + num8 + num9;
                var c = b % 11;

                var result = c < 2 && a == c || c >= 2 && 11 - c == a;
                if (result)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// صحت سنجی شناسه ملی شرکت‌ها
        /// </summary>
        /// <param name="nationalId"></param>
        /// <returns></returns>
        public static bool IsLegalNationalIdValid(this string nationalId)
        {
            if (string.IsNullOrWhiteSpace(nationalId) || !nationalId.IsLengthEqual(11))
                return false;

            if (!nationalId.IsNumeric())
                return false;

            if (!IsFormat1Validate(nationalId))
                return false;

            if (!IsFormat2Validate(nationalId))
                return false;
            return true;

            static bool IsFormat1Validate(string nationalId)
            {
                var allDigitEqual = new[] { "00000000000", "11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999" };
                if (!allDigitEqual.Contains(nationalId))
                    return true;
                return false;
            }

            static bool IsFormat2Validate(string nationalId)
            {
                var chArray = nationalId.ToCharArray();
                var controlCode = Convert.ToInt32(nationalId[10].ToString());
                var factor = Convert.ToInt32(nationalId[9].ToString()) + 2;
                var sum = 0;
                sum += (factor + Convert.ToInt32(chArray[0].ToString())) * 29;
                sum += (factor + Convert.ToInt32(chArray[1].ToString())) * 27;
                sum += (factor + Convert.ToInt32(chArray[2].ToString())) * 23;
                sum += (factor + Convert.ToInt32(chArray[3].ToString())) * 19;
                sum += (factor + Convert.ToInt32(chArray[4].ToString())) * 17;
                sum += (factor + Convert.ToInt32(chArray[5].ToString())) * 29;
                sum += (factor + Convert.ToInt32(chArray[6].ToString())) * 27;
                sum += (factor + Convert.ToInt32(chArray[7].ToString())) * 23;
                sum += (factor + Convert.ToInt32(chArray[8].ToString())) * 19;
                sum += (factor + Convert.ToInt32(chArray[9].ToString())) * 17;
                var remaining = sum % 11;
                if (remaining == 10)
                    remaining = 0;
                return remaining == controlCode;
            }
        }

        private static bool IsNumeric(this string nationalCode)
        {
            var regex = new Regex(@"\d+");
            if (regex.IsMatch(nationalCode))
                return true;
            return false;
        }

        private static bool IsLengthEqual(this string input, int lenght)
        {
            return input.Length == lenght;
        }


        private static bool IsLengthBetween(this string input, int minLength, int maxLenght)
        {
            if (input.Length <= maxLenght && input.Length >= minLength)
                return true;
            return false;
        }
    }
}
