using MediatR;
using StoreManagement.Domain;
using System.Collections.Generic;

namespace StoreManagement.Application.Queries
{
    public class GetAllProductsQuery : IRequest<List<Product>>
    {

    }
}
