using MediatR;
using StoreManagement.Data.Infrastructure.UnitOfWorks;
using StoreManagement.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagement.Application.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly IStoreUnitOfWork storeUnitOfWork;

        public GetAllProductsQueryHandler(IStoreUnitOfWork storeUnitOfWork)
        {
            this.storeUnitOfWork = storeUnitOfWork;
        }
        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return (List<Product>)await storeUnitOfWork.ProductRepository.GetAllAsync();
        }
    }
}
