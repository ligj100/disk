using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disk.Core.Domain.Members
{
    public  partial  class Member : BaseEntity
    {
        private ICollection<Role> _MemberRoles;

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


        /// <summary>
        /// 获取或设置用户手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets the affiliate identifier
        /// </summary>
        public int AffiliateId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer is active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer has been deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the last IP address
        /// </summary>
        public string LastIpAddress { get; set; }

        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the date and time of last login
        /// </summary>
        public DateTime? LastLoginDate { get; set; }


        /// <summary>
        /// Gets or sets the customer roles
        /// </summary>
        public virtual ICollection<Role> MemberRoles
        {
            get { return _MemberRoles ?? (_MemberRoles = new List<Role>()); }
            protected set { _MemberRoles = value; }
        }
    }
}
