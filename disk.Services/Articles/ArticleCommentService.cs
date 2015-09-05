using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using disk.Core.Caching;
using disk.Core.Data;
using disk.Core.Domain.Articles;
using disk.Core.Log;
using disk.Services.Events;

namespace disk.Services.Articles
{
    public partial class ArticleCommentService : BaseServices<ArticleComment>, IArticleCommentService
    {
        private static readonly IDiskLogger logger = DiskLogProvider.LogInstance.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IRepository<ArticleComment> _Repository;
        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;

        public ArticleCommentService(ICacheManager cacheManager, IRepository<ArticleComment> Repository, IEventPublisher eventPublisher)
            : base(cacheManager, Repository, eventPublisher)
        {
            _cacheManager = cacheManager;
            _Repository = Repository;
            _eventPublisher = eventPublisher;
        }
    }
}
