using brk.Framework.Base.Utils;
using Microsoft.AspNetCore.Http;

namespace brk.Framework.Base.Web.Services
{
    public interface IUserInfoService
    {
        long GetUserId();
    }


    public class UserInfoService : IUserInfoService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserInfoService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public long GetUserId()=> _contextAccessor.HttpContext?.User.GetUserId() ?? 0;
    }
}
