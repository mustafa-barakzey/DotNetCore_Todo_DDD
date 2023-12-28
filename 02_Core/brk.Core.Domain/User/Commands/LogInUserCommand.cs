using brk.Core.Domain.User.Query;
using brk.Framework.Base.Application;
using System.ComponentModel.DataAnnotations;

namespace brk.Core.Domain.User.Commands
{
    /// <summary>
    /// دستور ورود کاربر
    /// </summary>
    public class LogInUserCommand : ICommand<LogInUserQueryResult>
    {
        /// <summary>ایمیل </summary>
        [Required(ErrorMessage = "ایمیل")]
        public string Email { get; set; }

        /// <summary>کلمه عبور </summary>
        [Required(ErrorMessage = "کلمه عبور")]
        public string Password { get; set; }
    }
}
