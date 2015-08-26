using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disk.Core.Domain.Members
{
    public partial class Role : BaseEntity
    {
        /// <summary>
        /// 获取或设置角色名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置角色描述
        /// </summary>
        public string Desc { get; set; }
    }
}
