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
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDetails>
    {
        private readonly IStoreUnitOfWork storeUnitOfWork;

        public GetProductByIdQueryHandler(IStoreUnitOfWork storeUnitOfWork)
        {
            this.storeUnitOfWork = storeUnitOfWork;
        }
        public async Task<ProductDetails> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Product product = await storeUnitOfWork.ProductRepository.GetWithDetailsAsync(request.Id);

            if (product != null)
            {
                ProductDetails readingProduct = new()
                {
                    Id = product.Id,
                    Brand = product.Brand,
                    Category = product.Category,
                    Created = product.Created,
                    Description = product.Description,
                    Name = product.Name,
                    Price = product.Price,
                    Updated = product.Updated,
                };

                return readingProduct;
            }
            else
                return null;
        }
    }
}
