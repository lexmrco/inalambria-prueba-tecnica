using Microsoft.EntityFrameworkCore;
using Inalambria.Infrastructure.Mapping;
using Inalambria.Domain.Entities;

namespace Inalambria.Infrastructure
{
    public class InalambriaDbContext : DbContext
    {
        public InalambriaDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderDetailsMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
        }
    }
}
