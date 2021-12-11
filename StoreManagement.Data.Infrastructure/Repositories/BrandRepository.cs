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
    public class BrandRepository : EFGenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(StoreDbContext context) : base(context)
        {
            
        }

        private StoreDbContext AppDbContext
        {
            get { return Context as StoreDbContext; }
        }
    }
}
