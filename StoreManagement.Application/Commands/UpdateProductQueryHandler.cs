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
            #region check if object exist
            Product product = await storeUnitOfWork.ProductRepository.GetByIdAsync(request.Id);
            if (product == null)
                throw new ProductNotFoundException();
            #endregion

            #region associated Brand
            Brand assocBrand = await storeUnitOfWork.BrandRepository.GetByIdAsync(request.BrandId);
            if (assocBrand == null)
                throw new BrandNotFoundException();
            #endregion

            #region associated Category
            Category assocCategory = await storeUnitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId);
            if (assocCategory == null)
                throw new CategoryNotFoundException();
            #endregion

            product.Name = request.Name;
            product.Brand = assocBrand;
            product.BrandId = assocBrand.Id;
            product.Category = assocCategory;
            product.CategoryId = assocCategory.Id;
            product.Updated = DateTime.UtcNow;
            product.Description = request.Description;
            product.Price = request.Price;

            storeUnitOfWork.ProductRepository.UpdateAsync(product);
            await storeUnitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
