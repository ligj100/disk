
using System.ComponentModel.DataAnnotations.Schema;
using disk.Core.Domain.Articles;

namespace disk.Data.Mapping.Articles
{
    public partial class ArticlePostMap : DiskEntityTypeConfiguration<ArticlePost>
    {
        public ArticlePostMap()
        {
            this.ToTable("ArticlePost");
            this.HasKey(c => c.Id);
            //this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);//设置自增属性
            this.Property(c => c.Title).IsRequired().HasMaxLength(300);
            this.Property(c => c.Body).IsRequired();
            this.HasRequired(c => c.Member).WithOptional();
            //设置与评论的一对多关系，article必有，comments可选，设置外键 articlePostId,级联删除
            //this.HasOptional(c=>c.ArticleComments).WithRequired().WillCascadeOnDelete();
            this.HasMany(c => c.ArticleCategory).WithMany(c => c.ArticlePost).Map(m=>m.ToTable("Article_Category_Map"));
        }
    }
}
