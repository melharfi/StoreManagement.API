using MediatR;
using StoreManagement.Data.Infrastructure.UnitOfWorks;
using StoreManagement.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using StoreManagement.Application.Exceptions;

namespace StoreManagement.Application.Commands
{
    public class CreateBrandQueryHandler : IRequestHandler<CreateBrandQuery, Guid>
    {
        private readonly IStoreUnitOfWork storeUnitOfWork;

        public CreateBrandQueryHandler(IStoreUnitOfWork storeUnitOfWork)
        {
            this.storeUnitOfWork = storeUnitOfWork;
        }
        public async Task<Guid> Handle(CreateBrandQuery request, CancellationToken cancellationToken)
        {
            var result = await storeUnitOfWork.BrandRepository.SingleOrDefaultAsync(f => f.Name == request.Name);
            if (result != null)
                throw new BrandNameDuplicationException();

            Brand brand = new()
            {
                Name = request.Name
            };

            await storeUnitOfWork.BrandRepository.AddAsync(brand);
            await storeUnitOfWork.CommitAsync();
            return brand.Id;
        }
    }
}
