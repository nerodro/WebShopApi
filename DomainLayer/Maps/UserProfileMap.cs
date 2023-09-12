using DomainLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Maps
{
    public class UserProfileMap
    {
        public UserProfileMap(EntityTypeBuilder<UserProfile> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.LastName)/*.IsRequired()*/;
            entityBuilder.Property(t => t.Address);
            entityBuilder.Property(t => t.Phone);
            entityBuilder.Property(t => t.PostalCode);
            entityBuilder.Property(t => t.City);
            entityBuilder.Property(t => t.CardNumber);
            entityBuilder.Property(t => t.CSVCode);
            entityBuilder.Property(t => t.DateExpireCard);
            //entityBuilder.HasOne(t=> t.Cart).WithOne(u => u.UserProfile).HasForeignKey<Cart>(x=> x.UserProfileId);
        }
    }
}
