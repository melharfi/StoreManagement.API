using MediatR;
using StoreManagement.Domain;
using System.Collections.Generic;

namespace StoreManagement.Application.Queries
{
    public class GetAllBrandsQuery : IRequest<List<Brand>>
    {

    }
}
