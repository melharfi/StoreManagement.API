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
    public class GetProductsPaginationQueryHandler : IRequestHandler<GetProductsPaginationQuery, ProductPagination>
    {
        private readonly IStoreUnitOfWork storeUnitOfWork;
        private readonly ProductPagination productPagination;

        public GetProductsPaginationQueryHandler(IStoreUnitOfWork storeUnitOfWork, ProductPagination productPagination)
        {
            this.storeUnitOfWork = storeUnitOfWork;
            this.productPagination = productPagination;
        }
        public async Task<ProductPagination> Handle(GetProductsPaginationQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = await storeUnitOfWork.ProductRepository.GetByPaginationAsync(request.PageIndex, request.PageSize);
            int collectionSize = storeUnitOfWork.ProductRepository.GetAllAsync().Result.Count();
            int pagesCount = collectionSize / request.PageSize;
            Console.WriteLine(pagesCount);
            productPagination.Products = products;
            productPagination.CollectionSize = collectionSize;

            return productPagination;
        }
    }
}
