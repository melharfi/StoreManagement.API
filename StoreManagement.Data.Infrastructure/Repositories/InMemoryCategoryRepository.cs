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
    public class InMemoryCategoryRepository : EFGenericRepository<Category>, IInMemoryCategoryRepository
    {
        DbContextOptions<DbContext> options;
        public InMemoryCategoryRepository(InMemoryStoreDbContext context) : base(context)
        {
            options = new DbContextOptionsBuilder<DbContext>()
            .UseInMemoryDatabase(databaseName: "StoreDB")
            .Options;
        }

        private InMemoryStoreDbContext AppDbContext
        {
            get { return Context as InMemoryStoreDbContext; }
        }
    }
}
