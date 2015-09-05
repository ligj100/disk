using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using disk.Core;
using disk.Core.Domain.Articles;

namespace disk.Services.Articles
{
    public partial interface IArticlePostService : IBaseServices<ArticlePost>
    {
        IPagedList<ArticlePost> GetPagedList(int pageIndex, int pageSize);
    }
}
