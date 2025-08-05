using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext:DbContext
    {
        public DbSet<Coupon> Coupons { get; set; } = default!;
        public DiscountContext(DbContextOptions<DiscountContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                    new Coupon { Id=1, ProductName="Samsung S25 ultra",Description="Samsung S22 ultra discount",Amount=150},
                    new Coupon { Id = 2, ProductName = "iPhone 14 pro", Description = "iPhone 14 pro discount", Amount = 100 }
                );
        }
    }
}
