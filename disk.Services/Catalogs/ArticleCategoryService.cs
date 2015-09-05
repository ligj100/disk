using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using disk.Core.Caching;
using disk.Core.Data;
using disk.Core.Domain.Catalogs;
using disk.Core.Log;
using disk.Services.Events;

namespace disk.Services.Catalogs
{
    public partial class ArticleCategoryService : BaseServices<ArticleCategory>, IArticleCategoryService
    {
        private static readonly IDiskLogger logger = DiskLogProvider.LogInstance.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IRepository<ArticleCategory> _Repository;
        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;

        public ArticleCategoryService(ICacheManager cacheManager, IRepository<ArticleCategory> Repository, IEventPublisher eventPublisher)
            : base(cacheManager, Repository, eventPublisher)
        {
            _cacheManager = cacheManager;
            _Repository = Repository;
            _eventPublisher = eventPublisher;
        }
    }
}
