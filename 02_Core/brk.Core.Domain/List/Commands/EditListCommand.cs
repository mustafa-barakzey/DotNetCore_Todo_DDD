using brk.Framework.Base.Application;
using brk.Framework.Localization.List;
using System.ComponentModel.DataAnnotations;

namespace brk.Core.Domain.List.Commands
{
    public class EditListCommand : ICommand
    {
        public long Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(ListResource),ErrorMessageResourceName =nameof(ListResource.Title_Is_Required))]
        public string Title { get; set; }
    }
}
