using Microsoft.EntityFrameworkCore;
using MyApp.Context.Domain.Mapping;
using MyApp.Context.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Domain
{
    public class ProductCatelogContext : DbContext
    {

        public ProductCatelogContext(DbContextOptions<ProductCatelogContext> options) : base(options)
        {
            //Created the database if not exists
            this.Database.EnsureCreated();
        }

        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ProductMap(modelBuilder.Entity<Product>());
        }
    }

}
