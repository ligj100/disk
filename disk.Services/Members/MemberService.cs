using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using disk.Core.Caching;
using disk.Core.Data;
using disk.Core.Domain.Members;
using disk.Core.Log;
using disk.Services.Events;

namespace disk.Services.Members
{
    public partial class MemberService:BaseServices<Member>, IMemberService
    {
        
        private static readonly IDiskLogger logger = DiskLogProvider.LogInstance.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IRepository<Member> _memberRepository;
        private readonly ICacheManager _cacheManager;
        private readonly IEventPublisher _eventPublisher;

        public MemberService(ICacheManager cacheManager, IRepository<Member> memberRepository, IEventPublisher eventPublisher)
            : base(cacheManager, memberRepository, eventPublisher)
        {
            _cacheManager = cacheManager;
            _memberRepository = memberRepository;
            _eventPublisher = eventPublisher;
        }

        public virtual void InsertMember(Member member)
        {
            
            if (member == null)
                throw new ArgumentNullException("member");
            logger.Debug("Insert Member!");

            _memberRepository.Insert(member);

            //event notification
            //_eventPublisher.EntityInserted(Member);
        }
    }
}
