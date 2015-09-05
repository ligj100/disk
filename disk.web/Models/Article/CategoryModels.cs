using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using disk.web.Validators.Article;
using disk.Web.Framework.Mvc;
using FluentValidation.Attributes;

namespace disk.web.Models.Article
{
    [Validator(typeof(CategoryValidator))]
    public class CategoryModels : BaseDiskEntityModel
    {
        [Display(Name="分类名称")]
        public string Name { get; set; }

        [Display(Name = "分类描述")]
        public string Description { get; set; }

        [Display(Name = "SEO关键词")]
        public string MetaKeywords { get; set; }

        [Display(Name = "SEO描述")]
        public string MetaDescription { get; set; }

        
        [Display(Name = "SEO标题")]
        public string MetaTitle { get; set; }

        [Display(Name = "父级分类")]
        public int? ParentCategoryId { get; set; }

        [Display(Name = "是否在首页显示")]
        public bool ShowOnHomePage { get; set; }

        [Display(Name = "是否显示在导航栏")]
        public bool IncludeInTopMenu { get; set; }

        [Display(Name = "是否发布")]
        public bool Published { get; set; }

        [Display(Name = "分类排序")]
        public int DisplayOrder { get; set; }
    }
}