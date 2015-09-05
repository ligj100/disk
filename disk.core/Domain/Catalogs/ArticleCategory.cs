using System;
using System.Collections.Generic;
using disk.Core.Domain.Articles;
using disk.Core.Domain.Security;


namespace disk.Core.Domain.Catalogs
{
    /// <summary>
    /// Represents a category
    /// </summary>
    public partial class ArticleCategory : BaseEntity
    {
        private ICollection<ArticlePost> _ArticlePost;

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }


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
        /// Gets or sets the parent category identifier
        /// </summary>
        public int ParentCategoryId { get; set; }


        /// <summary>
        /// Gets or sets the page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customers can select the page size
        /// </summary>
        public bool AllowCustomersToSelectPageSize { get; set; }

        /// <summary>
        /// Gets or sets the available customer selectable page size options
        /// </summary>
        public string PageSizeOptions { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether to show the category on home page
        /// </summary>
        public bool ShowOnHomePage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include this category in the top menu
        /// </summary>
        public bool IncludeInTopMenu { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether the entity is published
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity has been deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance update
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// 静态化之后的第一页路径
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the customer roles
        /// </summary>
        public virtual ICollection<ArticlePost> ArticlePost
        {
            get { return _ArticlePost ?? (_ArticlePost = new List<ArticlePost>()); }
            protected set { _ArticlePost = value; }
        }

    }
}
