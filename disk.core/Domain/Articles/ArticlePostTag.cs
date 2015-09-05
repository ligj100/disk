namespace disk.Core.Domain.Articles
{
    /// <summary>
    /// Represents a blog post tag
    /// </summary>
    public partial class ArticlePostTag
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tagged product count
        /// </summary>
        public int ArticlePostCount { get; set; }
    }
}