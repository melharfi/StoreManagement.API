using StoreManagement.Data.EF.Infrastructure;
using StoreManagement.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreManagement.Data.Infrastructure.Repositories
{
    public interface ICategoryRepository : IEFGenericRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllAsync();
        //Task<Category> GetWithRoomById(Guid id);
        //TODO maybe add a reservationId in model and a methode to fetch it here
    }
}
