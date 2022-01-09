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
    public class CategoryRepository : EFGenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(StoreDbContext context) : base(context)
        {

        }

        private StoreDbContext AppDbContext
        {
            get { return Context as StoreDbContext; }
        }

        public Task<List<Category>> GetByPaginationAsync(int pageIndex, int pageSize)
        {
            return Task.FromResult(AppDbContext.Categories
                .OrderBy(f => f.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList());
        }
    }
}
