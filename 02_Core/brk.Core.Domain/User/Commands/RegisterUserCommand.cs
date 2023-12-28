using brk.Framework.Base.Application;
using System.ComponentModel.DataAnnotations;

namespace brk.Core.Domain.User.Commands;

/// <summary>
/// دستور ثبت نام کاربر
/// </summary>
public class RegisterUserCommand : ICommand
{
    /// <summary>نام </summary>
    [Required(ErrorMessage ="نام اجباری میباشد")]
    public string FirstName { get; set; }

    /// <summary>نام خانوادگی </summary>
    [Required(ErrorMessage = "نام خانوادگی اجباری میباشد")]
    public string LastName { get; set; }

    /// <summary>ایمیل </summary>
    [Required(ErrorMessage = "ایمیل")]
    public string Email { get; set; }

    /// <summary>کلمه عبور </summary>
    [Required(ErrorMessage = "کلمه عبور")]
    public string Password { get; set; }
}