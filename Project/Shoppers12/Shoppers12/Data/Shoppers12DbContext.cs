using Microsoft.EntityFrameworkCore;
using Shoppers12.Models.Data;
using System;

namespace Shoppers12.Data
{
    public class Shoppers12DbContext : DbContext
    {
        public Shoppers12DbContext(DbContextOptions<Shoppers12DbContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
