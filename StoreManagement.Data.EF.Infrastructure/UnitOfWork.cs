using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Data.EF.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
