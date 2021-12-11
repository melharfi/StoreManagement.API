using MediatR;
using StoreManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Application.Queries
{
    public class GetAllCategoriesQuery : IRequest<List<Category>>
    {
    }
}
