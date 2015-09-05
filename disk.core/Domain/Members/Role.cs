using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disk.Core.Domain.Members
{
    public partial class Role : BaseEntity
    {
        private ICollection<Member> _RoleMembers;
        /// <summary>
        /// 获取或设置角色名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置角色是否可用
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// 获取或设置角色描述
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Gets or sets the customer roles
        /// </summary>
        public virtual ICollection<Member> RoleMembers
        {
            get { return _RoleMembers ?? (_RoleMembers = new List<Member>()); }
            protected set { _RoleMembers = value; }
        }
    }
}
