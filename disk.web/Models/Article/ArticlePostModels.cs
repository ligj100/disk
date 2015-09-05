using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using disk.Core.Domain.Catalogs;
using disk.web.Validators.Article;
using disk.Web.Framework.Mvc;
using FluentValidation.Attributes;

namespace disk.web.Models.Article
{
    [Validator(typeof(ArticlePostValidator))]
    public class ArticlePostModels : BaseDiskEntityModel
    {
        private ICollection<ArticleCategory> _categories;

        public ArticlePostModels()
        {
            Comments = new List<ArticleCommentModels>();
        }

        [Display(Name="文章标题")]
        public string Title { get; set; }

        [AllowHtml]
        [Display(Name ="正文")]
        public string Body { get; set; }

        [AllowHtml]
        [Display(Name="摘要")]
        public string Intro { get; set; }

        [Display(Name="标签")]
        public string Tags { get; set; }

        [Display(Name = "SEO关键词")]
        public string MetaKeywords { get; set; }

        [Display(Name="SEO描述")]
        public string MetaDescription { get; set; }

        [Display(Name="SEO标题")]
        public string MetaTitle { get; set; }
        
        [Display(Name="创建日期")]
        public DateTime CreatedOnUtc { get; set; }

        public IList<ArticleCommentModels> Comments { get; set; }

        /// <summary>
        /// 分类Id,多个Id之间使用半角逗号分开
        /// </summary>
        [Display(Name="分类Id")]
        public string CategoryIds { get; set; }

        /// <summary>
        /// 文章分类
        /// </summary>
        public virtual ICollection<ArticleCategory> ArticleCategory
        {
            get { return _categories ?? (_categories = new List<ArticleCategory>()); }
            protected set { _categories = value; }
        }
    }
}