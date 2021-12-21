using MediatR;
using StoreManagement.Application.Exceptions;
using StoreManagement.Data.Infrastructure.UnitOfWorks;
using StoreManagement.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagement.Application.Commands
{
    public class UpdateProductQueryHandler : IRequestHandler<UpdateProductQuery>
    {
        private readonly IStoreUnitOfWork storeUnitOfWork;

        public UpdateProductQueryHandler(IStoreUnitOfWork storeUnitOfWork)
        {
            this.storeUnitOfWork = storeUnitOfWork;
        }
        public async Task<Unit> Handle(UpdateProductQuery request, CancellationToken cancellationToken)
        {
            #region check if there's already an existing brand with same name to avoid duplication
            Product original = await storeUnitOfWork.ProductRepository.GetByIdAsync(request.Id);
            if (original == null)
                throw new ProductNotFoundException();
            #endregion

            Product product = new()
            {
                Name = request.Name,
                Id = request.Id,
                Brand = request.Brand,
                BrandId = request.BrandId,
                Category = request.Category,
                CategoryId = request.CategoryId,
                Updated = DateTime.UtcNow
            };

            await storeUnitOfWork.ProductRepository.AddAsync(product);
            await storeUnitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
