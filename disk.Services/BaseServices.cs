using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using disk.Core;
using disk.Core.Caching;
using disk.Core.Data;
using disk.Core.Log;
using disk.Services.Events;

namespace disk.Services
{
    public partial class BaseServices<T>:IBaseServices<T> where T:BaseEntity
    {
        private static readonly IDiskLogger logger = DiskLogProvider.LogInstance.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        internal readonly IRepository<T> _Repository;
        internal readonly ICacheManager _cacheManager;
        internal readonly IEventPublisher _eventPublisher;

        public BaseServices(ICacheManager cacheManager, IRepository<T> Repository, IEventPublisher eventPublisher)
        {
            _cacheManager = cacheManager;
            _Repository = Repository;
            _eventPublisher = eventPublisher;
        }

        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _Repository.Insert(entity);

            //event notification
            _eventPublisher.EntityInserted(entity);
        }

        public void Modify(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _Repository.Update(entity);

            // //event notification
            _eventPublisher.EntityUpdated(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _Repository.Delete(entity);

            //event notification
            _eventPublisher.EntityDeleted(entity);
        }

        public T GetById(int Id)
        {
            if (Id == 0) return null;
            return _Repository.GetById(Id);
        }
    }
}
