using MediatR;
using StoreManagement.Application.Exceptions;
using StoreManagement.Data.Infrastructure.UnitOfWorks;
using StoreManagement.Domain;
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
            #region check if there's already an existing brand with same name to avoid duplication
            Brand original = await storeUnitOfWork.BrandRepository.GetByIdAsync(request.Id);
            if (original == null)
                throw new CategoryNotFoundException();
            #endregion

            Brand Brand = new()
            {
                Name = request.Name
            };

            await storeUnitOfWork.BrandRepository.AddAsync(Brand);
            await storeUnitOfWork.CommitAsync();

            return Unit.Value;
        }

    }
}
