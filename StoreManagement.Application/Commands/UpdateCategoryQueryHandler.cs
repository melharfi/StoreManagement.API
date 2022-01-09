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
            #region check if object exist
            Category category = await storeUnitOfWork.CategoryRepository.GetByIdAsync(request.Id);
            if (category == null)
                throw new CategoryNotFoundException();
            #endregion

            category.Name = request.Name;
            category.Updated = DateTime.UtcNow;

            storeUnitOfWork.CategoryRepository.UpdateAsync(category);
            await storeUnitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
