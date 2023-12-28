namespace brk.Endpoints.WebApi.Services.JWT
{
    public interface IJwtManager
    {
        /// <summary>
        /// ساخت توکن
        /// </summary>
        /// <typeparam name="TID">نوع شناسه کاربر</typeparam>
        /// <param name="userId">شناسه کاربر</param>
        /// <param name="userName">نام کاربری</param>
        /// <returns></returns>
        Token GenerateToken<TID>(TID userId,string userName);
    }
}
