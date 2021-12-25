using MediatR;
using StoreManagement.Application.Exceptions;
using StoreManagement.Data.Infrastructure.UnitOfWorks;
using StoreManagement.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagement.Application.Commands
{
    public class CreateCategoryQueryHandler : IRequestHandler<CreateCategoryQuery, Guid>
    {
        private readonly IStoreUnitOfWork storeUnitOfWork;

        public CreateCategoryQueryHandler(IStoreUnitOfWork storeUnitOfWork)
        {
            this.storeUnitOfWork = storeUnitOfWork;
        }
        public async Task<Guid> Handle(CreateCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await storeUnitOfWork.CategoryRepository.SingleOrDefaultAsync(f => f.Name == request.Name);
            if (result != null)
                throw new CategoryNameDuplicationException();

            Category category = new()
            {
                Name = request.Name
            };

            await storeUnitOfWork.CategoryRepository.AddAsync(category);
            await storeUnitOfWork.CommitAsync();
            return category.Id;
        }
    }
}
