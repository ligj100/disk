using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using disk.Core;
using disk.Core.Caching;
using disk.Core.Data;
using disk.Core.Domain.Articles;
using disk.Core.Log;
using disk.Services.Events;

namespace disk.Services.Articles
{
    public partial class ArticlePostService : BaseServices<ArticlePost>, IArticlePostService
    {
        #region Fields
        private static readonly IDiskLogger logger = DiskLogProvider.LogInstance.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IRepository<ArticlePost> _Repository;
        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;
        #endregion
        #region Ctor
        public ArticlePostService(ICacheManager cacheManager, IRepository<ArticlePost> Repository, IEventPublisher eventPublisher)
            : base(cacheManager, Repository, eventPublisher)
        {
            _cacheManager = cacheManager;
            _Repository = Repository;
            _eventPublisher = eventPublisher;
        }
        #endregion

        #region Method

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IPagedList<ArticlePost> GetPagedList(int pageIndex, int pageSize)
        {
            var query = _Repository.Table;
            query = from ap in query
                select ap;
            query = query.OrderByDescending(b => b.CreatedOnUtc);
            var artiblePosts = new PagedList<ArticlePost>(query,pageIndex,pageSize);
            
            return artiblePosts;
        }

        #endregion
    }
}
