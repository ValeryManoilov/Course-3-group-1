using Microsoft.EntityFrameworkCore;
using Practice13.Models;

namespace Practice13.Context
{
    public class DeliveryAppContext : DbContext
    {
        public DeliveryAppContext(DbContextOptions<DeliveryAppContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderProduct>()
                .HasKey(p => new { p.OrderId, p.ProductId });

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.OrderCustomer)
                .HasForeignKey("CustomerId");

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderProducts)
                .WithOne(od => od.Order)
                .HasForeignKey("OrderId");

            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderProducts)
                .WithOne(od => od.Product)
                .HasForeignKey("ProductId");
        }
    }
}
