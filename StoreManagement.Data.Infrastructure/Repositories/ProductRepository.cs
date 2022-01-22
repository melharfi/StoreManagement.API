using Microsoft.EntityFrameworkCore;
using StoreManagement.Data.EF.Infrastructure;
using StoreManagement.Data.Infrastructure.Models;
using StoreManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Data.Infrastructure.Repositories
{
    public class ProductRepository : EFGenericRepository<Product>, IProductRepository
    {
        public ProductRepository(StoreDbContext context) : base(context)
        {

        }


        private StoreDbContext AppDbContext
        {
            get { return Context as StoreDbContext; }
        }

        public async Task<Product> GetWithDetailsAsync(Guid id)
        {
            return await AppDbContext.Products.
                Include(f => f.Brand).
                Include(f => f.Category).
                FirstOrDefaultAsync(f => f.Id == id);

        }
        public async Task<IEnumerable<Product>> GetAllWithDetailsAsync()
        {
            return await AppDbContext.Products.
                Include(f => f.Brand).
                Include(f => f.Category).
                ToListAsync();
        }

        public Task<List<Product>> GetByPaginationAsync(int pageIndex, int pageSize)
        {
            return Task.FromResult(AppDbContext.Products
                .Include(f => f.Category)
                .Include(f => f.Brand)
                .AsEnumerable()
                .OrderBy(f => f.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList());
        }
    }
}
