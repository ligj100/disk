﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using disk.Core.Domain.Members;

namespace disk.Data.Mapping.Members
{
    public partial class RoleMap : DiskEntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.ToTable("Role");
            this.HasKey(c => c.Id);
            this.Property(u => u.Name).HasMaxLength(200);
            this.Property(c => c.Desc).HasMaxLength(1000);
        }
    }
}
