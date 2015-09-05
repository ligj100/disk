using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using disk.web.Models.Members;
using disk.Web.Framework.Validators;
using FluentValidation;

namespace disk.web.Validators.Member
{
    public class MemberValidator : BaseNopValidator<MemberModels>
    {
        public MemberValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("邮箱地址不能为空").EmailAddress().WithMessage("邮箱地址格式错误！");
            RuleFor(x => x.UName).NotEmpty().WithMessage("用户名不能为空").Length(5, 30).WithMessage("5-50个字符！");
            RuleFor(x => x.Pwd).NotEmpty().WithMessage("密码不能为空！");
            RuleFor(x => x.RePwd).NotEmpty().WithMessage("验证密码不能为空！");
        }
    }
}