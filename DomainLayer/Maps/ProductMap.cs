using DomainLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DomainLayer.Maps
{
    public class ProductMap
    {
        public ProductMap(EntityTypeBuilder<Products> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.ProductName).IsRequired();
            entityTypeBuilder.Property(x => x.ProductNumber).IsRequired();
            entityTypeBuilder.Property(x => x.Price).IsRequired();
            entityTypeBuilder.Property(x => x.ProductDescription).IsRequired();
            entityTypeBuilder.Property(x => x.Photos);
            entityTypeBuilder.Property(x => x.CategoryId).IsRequired();
            //entityTypeBuilder.HasOne(t => t.Cart).WithOne(u => u.Products).HasForeignKey<Cart>(x => x.ProductId);
        }
    }
}
