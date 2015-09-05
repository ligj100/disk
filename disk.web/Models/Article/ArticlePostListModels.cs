using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using disk.Web.Framework.Mvc;

namespace disk.web.Models.Article
{
    public partial class ArticlePostListModels : BaseDiskModel
    {
        public ArticlePostListModels()
        {
            ArticlePosts = new List<ArticlePostModels>();
            PagingFilteringContext = new ArticlePagingFilteringModel();
        }

        public ArticlePagingFilteringModel PagingFilteringContext { get; set; }
        public IList<ArticlePostModels> ArticlePosts { get; set; }
    }
}