using MediatR;
using StoreManagement.Application.Exceptions;
using StoreManagement.Data.Infrastructure.UnitOfWorks;
using StoreManagement.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagement.Application.Commands
{
    public class DeleteCategoryQueryHandler : IRequestHandler<DeleteCategoryQuery>
    {
        private readonly IStoreUnitOfWork storeUnitOfWork;

        public DeleteCategoryQueryHandler(IStoreUnitOfWork storeUnitOfWork)
        {
            this.storeUnitOfWork = storeUnitOfWork;
        }
        public async Task<Unit> Handle(DeleteCategoryQuery request, CancellationToken cancellationToken)
        {
            #region check if there's already an existing brand with same name to avoid duplication
            Category original = await storeUnitOfWork.CategoryRepository.GetByIdAsync(request.Id);
            if (original == null)
                throw new CategoryNotFoundException();
            #endregion

            storeUnitOfWork.CategoryRepository.RemoveById(request.Id);
            await storeUnitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
