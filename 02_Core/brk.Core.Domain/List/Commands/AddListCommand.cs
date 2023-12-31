using brk.Framework.Base.Application;
using System.ComponentModel.DataAnnotations;

namespace brk.Core.Domain.List.Commands
{
    public class AddListCommand : ICommand
    {
        [Required(ErrorMessage ="عنوان اجباری میباشد")]
        public string Title { get; set; }
    }
}
