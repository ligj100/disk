using disk.Core.Domain.Catalogs;

namespace disk.Data.Mapping.Catalogs
{
    public partial class ArticleCategoryMap : DiskEntityTypeConfiguration<ArticleCategory>
    {
        public ArticleCategoryMap()
        {
            this.ToTable("ArticleCategory");
            this.HasKey(c => c.Id);
            this.Property(c => c.ParentCategoryId).IsRequired();
            this.Property(u => u.Name).HasMaxLength(500);
            
        }
    }
}
