using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using disk.Core.Caching;
using disk.Core.Data;
using disk.Core.Domain.Members;

namespace disk.Services.Members
{
    public partial class MemberService:IMemberService
    {
        private readonly IRepository<Member> _memberRepository;
        private readonly ICacheManager _cacheManager;

        public MemberService(ICacheManager cacheManager,IRepository<Member> memberRepository)
        {
            _cacheManager = cacheManager;
            _memberRepository = memberRepository;
        }

        public virtual void InsertMember(Member member)
        {
            if (member == null)
                throw new ArgumentNullException("member");

            _memberRepository.Insert(member);

            //event notification
            //_eventPublisher.EntityInserted(customer);
        }
    }
}
