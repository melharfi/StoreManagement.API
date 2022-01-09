using MediatR;
using StoreManagement.Domain;

namespace StoreManagement.Application.Queries
{
    public class GetCategoriesPaginationQuery : IRequest<CategoryPagination>
    {

        public GetCategoriesPaginationQuery(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public int PageIndex { get; }
        public int PageSize { get; }
    }
}
