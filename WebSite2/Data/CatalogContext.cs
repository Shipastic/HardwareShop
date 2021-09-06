using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite2.Data.Models;

namespace WebSite2.Data
{
    public class CatalogContext : DbContext
    {
        /// <summary>
        /// Создаем конструктор по умолчанию
        /// </summary>
        /// <param name="options"></param>
        public CatalogContext(DbContextOptions<CatalogContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilterName>()
                        .HasOne(m => m.Product)
                        .WithMany(t => t.FilterNames)
                        .HasForeignKey(m => m.ProductId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FilterName>()
                        .HasOne(m => m.CatalogGroup)
                        .WithMany(t => t.FilterNames)
                        .HasForeignKey(m => m.CatalogGroupId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FilterName>()
                        .HasOne(m => m.FilterGroup)
                        .WithMany(t => t.FilterNames)
                        .HasForeignKey(m => m.FilterGroupId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CatalogGroup>()
                        .HasOne(m => m.MainCategory)
                        .WithMany(t => t.CatalogGroups)
                        .HasForeignKey(m => m.MainCategoryId)
                        .OnDelete(DeleteBehavior.Restrict);
        }

        //Все модели передаются в БД через класс DbSet 
        public DbSet<CatalogGroup> CatalogGroups { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<PropertyValue> PropertyValues { get; set; }

        public DbSet<ShopProductItem> ShopProductItems { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<FilterName> FilterNames { get; set; }

        public DbSet<FilterGroup> FilterGroups { get; set; }

        public DbSet<MainCategory> MainCategories { get; set; }
    }
}