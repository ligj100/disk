using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using disk.Core.Domain.Articles;
using disk.Core.Domain.Members;
using disk.Web.Framework.Mvc;

namespace disk.web.Models.Article
{
    public class ArticleCommentModels : BaseDiskEntityModel
    {

        public int MemberId { get; set; }

        
        public string CommentText { get; set; }

        public int ArticlePostId { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public virtual string MemberName { get; set; }

        public virtual ArticlePost ArticlePost { get; set; }
    }
}