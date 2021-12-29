using MediatR;
using StoreManagement.Domain;

namespace StoreManagement.Application.Queries
{
    public class GetProductsPaginationQuery : IRequest<ProductPagination>
    {

        public GetProductsPaginationQuery(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public int PageIndex { get; }
        public int PageSize { get; }
    }
}
