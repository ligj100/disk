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
    public partial class RoleService:IRoleService
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly ICacheManager _cacheManager;

        public RoleService(ICacheManager cacheManager, IRepository<Role> roleRepository)
        {
            _cacheManager = cacheManager;
            _roleRepository = roleRepository;
        }
        public void Insert(Role role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            _roleRepository.Insert(role);

        }
    }
}
