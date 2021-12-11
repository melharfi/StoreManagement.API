using StoreManagement.Data.EF.Infrastructure;
using StoreManagement.Data.Infrastructure.Models;
using StoreManagement.Data.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Data.Infrastructure.UnitOfWorks
{
    public interface IStoreUnitOfWork : IUnitOfWork, IDisposable
    {
        StoreDbContext Context { get; }
        ICategoryRepository CategoryRepository { get; }
        IBrandRepository BrandRepository { get; }
        IProductRepository ProductRepository { get; }
    }
}
