using MediatR;
using StoreManagement.Application.Exceptions;
using StoreManagement.Data.Infrastructure.UnitOfWorks;
using StoreManagement.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagement.Application.Commands
{
    public class UpdateCategoryQueryHandler : IRequestHandler<UpdateCategoryQuery>
    {
        private readonly IStoreUnitOfWork storeUnitOfWork;

        public UpdateCategoryQueryHandler(IStoreUnitOfWork storeUnitOfWork)
        {
            this.storeUnitOfWork = storeUnitOfWork;
        }
        public async Task<Unit> Handle(UpdateCategoryQuery request, CancellationToken cancellationToken)
        {
            #region check if there's already an existing brand with same name to avoid duplication
            Category original = await storeUnitOfWork.CategoryRepository.GetByIdAsync(request.Id);
            if (original == null)
                throw new CategoryNotFoundException();
            #endregion

            Category category = new()
            {
                Name = request.Name
            };

            await storeUnitOfWork.CategoryRepository.AddAsync(category);
            await storeUnitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
