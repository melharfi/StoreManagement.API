using MediatR;
using StoreManagement.Application.Exceptions;
using StoreManagement.Data.Infrastructure.UnitOfWorks;
using StoreManagement.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagement.Application.Commands
{
    public class UpdateBrandQueryHandler : IRequestHandler<UpdateBrandQuery>
    {
        private readonly IStoreUnitOfWork storeUnitOfWork;

        public UpdateBrandQueryHandler(IStoreUnitOfWork storeUnitOfWork)
        {
            this.storeUnitOfWork = storeUnitOfWork;
        }
        public async Task<Unit> Handle(UpdateBrandQuery request, CancellationToken cancellationToken)
        {
            #region check if object exist
            Brand brand = await storeUnitOfWork.BrandRepository.GetByIdAsync(request.Id);
            if (brand == null)
                throw new CategoryNotFoundException();
            #endregion

            brand.Name = request.Name;
            brand.Updated = DateTime.UtcNow;

            storeUnitOfWork.BrandRepository.UpdateAsync(brand);
            await storeUnitOfWork.CommitAsync();

            return Unit.Value;
        }

    }
}
