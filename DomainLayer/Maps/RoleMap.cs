using DomainLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Maps
{
    public class RoleMap
    {
        public RoleMap(EntityTypeBuilder<Role> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.RoleName).IsRequired();
            //entityTypeBuilder.HasMany(x => x.User).WithOne(u => u.Role).HasForeignKey<User>(t => t.RoleId);
            // entityTypeBuilder.HasOne(x => x.UserProfile).WithOne(u => u.Role).HasForeignKey<UserProfile>(t => t.RoleId);
        }
    }
}
