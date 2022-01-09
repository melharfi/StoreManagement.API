using StoreManagement.Data.EF.Infrastructure;
using StoreManagement.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreManagement.Data.Infrastructure.Repositories
{
    public interface IProductRepository : IEFGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllWithDetailsAsync();
        Task<List<Product>> GetByPaginationAsync(int pageIndex, int elementsPerPage);
    }
}
