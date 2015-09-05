using System;
using System.Collections.Generic;
using disk.Core.Domain.Catalogs;
using disk.Core.Domain.Members;

namespace disk.Core.Domain.Articles
{
    /// <summary>
    /// Represents a blog post
    /// </summary>
    public partial class ArticlePost : BaseEntity
    {
        private ICollection<ArticleComment> _articleComments;
        private ICollection<ArticleCategory> _categories;

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int MemberId { get; set; }
        /// <summary>
        /// Gets or sets the blog post title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the blog post title
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string Intro { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the blog post comments are allowed 
        /// </summary>
        public bool AllowComments { get; set; }

        /// <summary>
        /// Gets or sets the total number of comments
        /// <remarks>
        /// We use this property for performance optimization (no SQL command executed)
        /// </remarks>
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        /// Gets or sets the blog tags
        /// </summary>
        public string Tags { get; set; }


        /// <summary>
        /// Gets or sets the meta keywords
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// Gets or sets the meta description
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// Gets or sets the meta title
        /// </summary>
        public string MetaTitle { get; set; }
        
 
        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 静态化之后的路径
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the Member
        /// </summary>
        public virtual Member Member { get; set; }

        /// <summary>
        /// Gets or sets the blog comments
        /// </summary>
        public virtual ICollection<ArticleComment> ArticleComments
        {
            get { return _articleComments ?? (_articleComments = new List<ArticleComment>()); }
            protected set { _articleComments = value; }
        }

        /// <summary>
        /// Gets or sets the blog Category
        /// </summary>
        public virtual ICollection<ArticleCategory> ArticleCategory
        {
            get { return _categories ?? (_categories = new List<ArticleCategory>()); }
            protected set { _categories = value; }
        }
    }
}