using Microsoft.EntityFrameworkCore;
using StoreManagement.Data.Infrastructure.Configurations;
using StoreManagement.Domain;

namespace StoreManagement.Data.Infrastructure.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new BrandConfiguration());

            builder
                .ApplyConfiguration(new CategoryConfiguration());

            builder
                .ApplyConfiguration(new ProductConfiguration());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
