﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using disk.Core.Domain.Members;

namespace disk.Data.Mapping.Members
{
    public partial class MemberMap : DiskEntityTypeConfiguration<Member>
    {
        public MemberMap()
        {
            this.ToTable("Member");
            this.HasKey(c => c.Id);
            //this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);//设置自增属性
            this.Property(u => u.Name).HasMaxLength(500);
            this.HasMany(c => c.MemberRoles)
                .WithMany(c=>c.RoleMembers)
                .Map(m => m.ToTable("Member_MemberRoles_Mapping"));
        }
    }
}
