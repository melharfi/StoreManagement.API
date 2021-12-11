using MediatR;
using StoreManagement.Data.Infrastructure.UnitOfWorks;
using StoreManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagement.Application.Queries
{
    public class GetAllBrandesQueryHandler : IRequestHandler<GetAllBrandsQuery, List<Brand>>
    {
        private readonly IStoreUnitOfWork storeUnitOfWork;

        public GetAllBrandesQueryHandler(IStoreUnitOfWork storeUnitOfWork)
        {
            this.storeUnitOfWork = storeUnitOfWork;
        }
        public async Task<List<Brand>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            return (List<Brand>)await storeUnitOfWork.BrandRepository.GetAllAsync();
        }
    }
}
