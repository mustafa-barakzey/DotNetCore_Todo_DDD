using brk.Core.Domain.User.Entities;
using brk.Core.Domain.User.ValueObjects;
using brk.Framework.Base.Data;
using brk.Framework.Base.ValueObjects;

namespace brk.Core.Domain.User.Data;


public interface IUserRepository : IBaseRepository
{
    /// <summary>
    /// افزودن کاربر جدید
    /// </summary>
    /// <param name="user">کاربر</param>
    /// <returns></returns>
    Task AddAsync(UserModel user);

    /// <summary>
    /// واکشی کاربر با ایمیل و کلمه عبور+
    /// </summary>
    /// <param name="email">ایمیل</param>
    /// <param name="password">کلمه عبور</param>
    /// <returns></returns>
    Task<UserModel> GetAsync(Email email, Password password);

    /// <summary>
    /// چک میکند آیا کاربری با ایمیل وارد شده وجود دارد ؟
    /// </summary>
    /// <param name="email">ایمیل</param>
    /// <returns></returns>
    Task<bool> IsExistAsync(Email email);
}