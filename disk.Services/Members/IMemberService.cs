using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using disk.Core.Domain.Members;

namespace disk.Services.Members
{
    public partial interface IMemberService
    {
        /// <summary>
        /// Insert a member
        /// </summary>
        /// <param name="member">Member</param>
        void InsertMember(Member member);
    }
}
