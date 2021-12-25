using MediatR;
using StoreManagement.Application.Exceptions;
using StoreManagement.Data.Infrastructure.UnitOfWorks;
using StoreManagement.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagement.Application.Commands
{
    public class CreateProductQueryHandler : IRequestHandler<CreateProductQuery, Guid>
    {
        private readonly IStoreUnitOfWork storeUnitOfWork;

        public CreateProductQueryHandler(IStoreUnitOfWork storeUnitOfWork)
        {
            this.storeUnitOfWork = storeUnitOfWork;
        }
        public async Task<Guid> Handle(CreateProductQuery request, CancellationToken cancellationToken)
        {
            var result = await storeUnitOfWork.ProductRepository.SingleOrDefaultAsync(f => f.Name == request.Name);
            if (result != null)
                throw new ProductNameDuplicationException();

            Product product = new()
            {
                Name = request.Name
            };

            await storeUnitOfWork.ProductRepository.AddAsync(product);
            await storeUnitOfWork.CommitAsync();
            return product.Id;
        }
    }
}
