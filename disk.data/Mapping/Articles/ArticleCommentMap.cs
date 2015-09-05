using System.ComponentModel.DataAnnotations.Schema;
using disk.Core.Domain.Articles;

namespace disk.Data.Mapping.Articles
{
    public partial class ArticleCommentMap : DiskEntityTypeConfiguration<ArticleComment>
    {
        public ArticleCommentMap()
        {
            this.ToTable("ArticleComment");
            this.HasKey(c => c.Id);
            //this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);//设置自增属性
            this.Property(u => u.CommentText).IsRequired();
            this.HasRequired(c=>c.ArticlePost).WithOptional().WillCascadeOnDelete();
        }
    }
}
