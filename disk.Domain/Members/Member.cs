using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disk.Domain.Members
{
    public  partial  class Member : BaseEntity
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public Member()
        {
            this.MemberGuid = Guid.NewGuid();
        }


        /// <summary>
        /// Gets or sets the Member Guid
        /// </summary>
        public Guid MemberGuid { get; set; }

        /// <summary>
        /// 获取或设置会员姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取可设置用户名
        /// </summary>
        public string UName { get; set; }

        /// <summary>
        /// 获取或设置用户密码
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// 获取或设置用户邮箱
        /// </summary>
        public string Email { get; set; }

    }
}
