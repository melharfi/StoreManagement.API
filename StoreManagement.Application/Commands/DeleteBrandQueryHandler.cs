using MediatR;
using StoreManagement.Application.Exceptions;
using StoreManagement.Data.Infrastructure.UnitOfWorks;
using StoreManagement.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagement.Application.Commands
{
    public class DeleteBrandQueryHandler : IRequestHandler<DeleteBrandQuery>
    {
        private readonly IStoreUnitOfWork storeUnitOfWork;

        public DeleteBrandQueryHandler(IStoreUnitOfWork storeUnitOfWork)
        {
            this.storeUnitOfWork = storeUnitOfWork;
        }
        public async Task<Unit> Handle(DeleteBrandQuery request, CancellationToken cancellationToken)
        {
            #region check if there's already an existing brand with same name to avoid duplication
            Brand original = await storeUnitOfWork.BrandRepository.GetByIdAsync(request.Id);
            if (original == null)
                throw new BrandNotFoundException();
            #endregion

            storeUnitOfWork.BrandRepository.RemoveById(request.Id);
            await storeUnitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
