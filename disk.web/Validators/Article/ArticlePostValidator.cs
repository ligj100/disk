using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using disk.web.Models.Article;
using disk.Web.Framework.Validators;
using FluentValidation;

namespace disk.web.Validators.Article
{
    public class ArticlePostValidator : BaseNopValidator<ArticlePostModels>
    {
        public ArticlePostValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("标题必填！");
            RuleFor(x => x.Body).NotEmpty().WithMessage("内容必填 !");
        }
    }
}