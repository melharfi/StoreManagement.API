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
    }
}
