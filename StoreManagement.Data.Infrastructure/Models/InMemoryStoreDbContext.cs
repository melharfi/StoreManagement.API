using Microsoft.EntityFrameworkCore;
using StoreManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Data.Infrastructure.Models
{
    public class InMemoryStoreDbContext : DbContext
    {
        public InMemoryStoreDbContext(DbContextOptions<DbContext> options)
        : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
