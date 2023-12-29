using System.Security.Claims;

namespace brk.Framework.Base.Utils
{
    internal static class Helper
    {
        public static long GetUserId(this ClaimsPrincipal principal)
        {
            var value = principal.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier)?.Value;
            if (value == null) return 0;
            return Int64.Parse(value);
        }
    }
}
