using CrazyPetals.Entities.Database;
using CrazyPetals.Repository.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<ActivityLog> ActivityLog { get; set; }
        public DbSet<AppTheme> AppTheme { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<ExternalLogin> ExternalLogin { get; set; }
        public DbSet<Filter> Filter { get; set; }
        public DbSet<FilterProduct> FilterProduct { get; set; }
        public DbSet<ForgotPassword> ForgotPassword { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderSummary> OrderSummary { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductColor> ProductColor { get; set; }
        public DbSet<ProductImages> ProductImage { get; set; }
        public DbSet<ProductSize> ProductSize { get; set; }
        public DbSet<Size> Size { get; set; }
        public DbSet<SmtpMail> SmtpMail { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }
        public DbSet<VersionControl> VersionControl { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
