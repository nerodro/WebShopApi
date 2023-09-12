using DomainLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Maps
{
    public class CartMap
    {
        public CartMap(EntityTypeBuilder<Cart> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.CountProduct).IsRequired();
            entityTypeBuilder.Property(x => x.SummaryPrice).IsRequired();
            //entityTypeBuilder.HasOne(t => t.Role).WithOne(u => u.User).HasForeignKey<Role>(x => x.Id);
        }
    }
}
