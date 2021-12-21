using MediatR;
using StoreManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Application.Commands
{
    public class DeleteCategoryQuery : IRequest
    {
        public Guid Id { get; set; }
        public DeleteCategoryQuery(Guid id)
        {
            Id = id;
        }
    }
}
