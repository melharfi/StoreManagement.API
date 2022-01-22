using MediatR;
using StoreManagement.Data.Infrastructure.UnitOfWorks;
using StoreManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StoreManagement.Application.Queries
{
    public class GetCategoriesPaginationQueryHandler : IRequestHandler<GetCategoriesPaginationQuery, CategoryPagination>
    {
        private readonly IStoreUnitOfWork storeUnitOfWork;
        private readonly CategoryPagination CategoryPagination;

        public GetCategoriesPaginationQueryHandler(IStoreUnitOfWork storeUnitOfWork, CategoryPagination CategoryPagination)
        {
            this.storeUnitOfWork = storeUnitOfWork;
            this.CategoryPagination = CategoryPagination;
        }
        public async Task<CategoryPagination> Handle(GetCategoriesPaginationQuery request, CancellationToken cancellationToken)
        {
            List<Category> _Categories = (List<Category>)await storeUnitOfWork.CategoryRepository.GetAllAsync();

            List<Category> Categories = await storeUnitOfWork.CategoryRepository.GetByPaginationAsync(request.PageIndex, request.PageSize);
            int collectionSize = storeUnitOfWork.CategoryRepository.GetAllAsync().Result.Count();
            CategoryPagination.Categories = Categories;
            CategoryPagination.CollectionSize = collectionSize;

            return CategoryPagination;
        }
    }
}
