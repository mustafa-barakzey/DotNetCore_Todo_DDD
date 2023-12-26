using brk.Framework.Base.Application;

namespace brk.Core.Domain.User.Commands;

/// <summary>
/// دستور ثبت نام کاربر
/// </summary>
public class RegisterUserCommand : ICommand
{
    /// <summary>نام </summary>
    public string FirstName { get; set; }

    /// <summary>نام خانوادگی </summary>
    public string LastName { get; set; }

    /// <summary>ایمیل </summary>
    public string Email { get; set; }
}