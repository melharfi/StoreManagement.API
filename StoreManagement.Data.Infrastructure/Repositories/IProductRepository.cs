using StoreManagement.Data.EF.Infrastructure;
using StoreManagement.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreManagement.Data.Infrastructure.Repositories
{
    public interface IProductRepository : IEFGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllAsync();
        //Task<Category> GetWithRoomById(Guid id);
        //TODO maybe add a reservationId in model and a methode to fetch it here
    }
}
