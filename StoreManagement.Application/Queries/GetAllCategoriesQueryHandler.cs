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
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<Category>>
    {
        private readonly IStoreUnitOfWork storeUnitOfWork;

        public GetAllCategoriesQueryHandler(IStoreUnitOfWork storeUnitOfWork)
        {
            this.storeUnitOfWork = storeUnitOfWork;
        }
        public async Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return (List<Category>)await storeUnitOfWork.CategoryRepository.GetAllAsync();
        }
    }
}
