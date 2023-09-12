using DomainLayer;
using DomainLayer.Maps;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Category> Category { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=WebShop2;Username=postgres;Password=nerodro26;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserMap(modelBuilder.Entity<User>());
            new RoleMap(modelBuilder.Entity<Role>());
            new CompanyMap(modelBuilder.Entity<Company>());
            new ProductMap(modelBuilder.Entity <Products>());
            new CartMap(modelBuilder.Entity<Cart>());
            new CategoryMap(modelBuilder.Entity<Category>());
            new UserProfileMap(modelBuilder.Entity<UserProfile>());


            Role adminRole = new Role { Id = 1, RoleName = "Admin" };
            Role moderRole = new Role { Id = 2, RoleName = "Moder" };
            Role userRole = new Role { Id = 3, RoleName = "User" };
            Role Seller = new Role { Id = 4, RoleName = "Seller" };
            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, moderRole, userRole, Seller });
            base.OnModelCreating(modelBuilder);
        }
    }
}
