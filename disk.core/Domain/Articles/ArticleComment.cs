using System;
using disk.Core.Domain.Members;

namespace disk.Core.Domain.Articles
{
    /// <summary>
    /// Represents a blog comment
    /// </summary>
    public partial class ArticleComment : BaseEntity
    {
        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// Gets or sets the comment text
        /// </summary>
        public string CommentText { get; set; }

        /// <summary>
        /// Gets or sets the blog post identifier
        /// </summary>
        public int ArticlePostId { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the Member
        /// </summary>
        public virtual Member Member { get; set; }

        /// <summary>
        /// Gets or sets the blog post
        /// </summary>
        public virtual ArticlePost ArticlePost { get; set; }
    }
}