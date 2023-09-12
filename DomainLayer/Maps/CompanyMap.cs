using DomainLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DomainLayer.Maps
{
    public class CompanyMap
    {
        public CompanyMap(EntityTypeBuilder<Company> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.CompanyNamme).IsRequired();
            entityTypeBuilder.Property(x => x.CompanyIdentity).IsRequired();
            //entityTypeBuilder.HasOne(t => t.Products).WithOne(u => u.Company).HasForeignKey<Products>(x => x.CompanyId);
        }
    }
}
