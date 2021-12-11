using StoreManagement.Data.EF.Infrastructure;
using StoreManagement.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreManagement.Data.Infrastructure.Repositories
{
    public interface IInMemoryCategoryRepository : IEFGenericRepository<Category>
    {
    }
}
