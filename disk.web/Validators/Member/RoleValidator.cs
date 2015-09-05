using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using disk.web.Models.Members;
using disk.Web.Framework.Validators;
using FluentValidation;

namespace disk.web.Validators.Member
{
    public class RoleValidator : BaseNopValidator<RoleModels>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("角色名称不能为空").Length(2, 50).WithMessage("2-50个字符！");
        }
    }
}