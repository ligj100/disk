using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using disk.web.Models.Article;
using disk.Web.Framework.Validators;
using FluentValidation;

namespace disk.web.Validators.Article
{
    public class CategoryValidator : BaseNopValidator<CategoryModels>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("分类名称必填!").Length(2, 50).WithMessage("2-50个字符");
            RuleFor(x => x.DisplayOrder).NotEmpty().WithMessage("分类排序必填!");
        }
    }
}