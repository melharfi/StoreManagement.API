using StoreManagement.Data.EF.Infrastructure;
using StoreManagement.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreManagement.Data.Infrastructure.Repositories
{
    public interface IProductRepository : IEFGenericRepository<Product>
    {
        Task<Product> GetWithDetailsAsync(Guid id);
        Task<IEnumerable<Product>> GetAllWithDetailsAsync();
        Task<List<Product>> GetByPaginationAsync(int pageIndex, int elementsPerPage);
    }
}
