using MediatR;
using StoreManagement.Application.Exceptions;
using StoreManagement.Data.Infrastructure.UnitOfWorks;
using StoreManagement.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagement.Application.Commands
{
    public class DeleteProductQueryHandler : IRequestHandler<DeleteProductQuery>
    {
        private readonly IStoreUnitOfWork storeUnitOfWork;

        public DeleteProductQueryHandler(IStoreUnitOfWork storeUnitOfWork)
        {
            this.storeUnitOfWork = storeUnitOfWork;
        }
        public async Task<Unit> Handle(DeleteProductQuery request, CancellationToken cancellationToken)
        {
            #region check if there's already an existing brand with same name to avoid duplication
            Product original = await storeUnitOfWork.ProductRepository.GetByIdAsync(request.Id);
            if (original == null)
                throw new ProductNotFoundException();
            #endregion

            storeUnitOfWork.ProductRepository.RemoveById(request.Id);
            await storeUnitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
