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
            #region check duplication
            var dupplication = await storeUnitOfWork.ProductRepository.SingleOrDefaultAsync(f => f.Name == request.Name);
            if (dupplication != null)
                throw new ProductNameDuplicationException();
            #endregion

            #region check if productId point to an existing product
            var assocBrand = await storeUnitOfWork.BrandRepository.SingleOrDefaultAsync(b => b.Id == request.BrandId);
            if (assocBrand == null)
                throw new ProductNotFoundException();
            #endregion

            #region
            var assocCategory = await storeUnitOfWork.CategoryRepository.SingleOrDefaultAsync(b => b.Id == request.CategoryId);
            if (assocCategory == null)
                throw new CategoryNotFoundException();
            #endregion

            Product product = new()
            {
                Name = request.Name,
                BrandId = assocBrand.Id,
                Brand = assocBrand,
                CategoryId = assocCategory.Id,
                Category = assocCategory,
                Price = request.Price,
                Description = request.Description
            };

            await storeUnitOfWork.ProductRepository.AddAsync(product);
            await storeUnitOfWork.CommitAsync();
            return product.Id;
        }
    }
}
