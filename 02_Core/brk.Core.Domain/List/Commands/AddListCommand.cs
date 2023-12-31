﻿using brk.Framework.Base.Application;
using brk.Framework.Localization.List;
using brk.Framework.Tools.Attributes;
using System.ComponentModel.DataAnnotations;

namespace brk.Core.Domain.List.Commands
{
    public class AddListCommand : ICommand
    {
        [Required(ErrorMessageResourceType = typeof(ListResource),ErrorMessageResourceName =nameof(ListResource.Title_Is_Required))]
        public string Title { get; set; }
    }
}
