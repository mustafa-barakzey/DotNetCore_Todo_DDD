using brk.Core.Domain.User.Entities;
using brk.Framework.Base.Data;
using brk.Framework.Base.ValueObjects;

namespace brk.Core.Domain.User.Data;


public interface IUserRepository:IBaseRepository
{
    /// <summary>
    /// افزودن کاربر جدید
    /// </summary>
    /// <param name="user">کاربر</param>
    /// <returns></returns>
    Task AddAsync(UserModel user);

    /// <summary>
    /// چک میکند آیا کاربری با ایمیل وارد شده وجود دارد ؟
    /// </summary>
    /// <param name="email">ایمیل</param>
    /// <returns></returns>
    Task<bool> IsExistAsync(Email email);
}