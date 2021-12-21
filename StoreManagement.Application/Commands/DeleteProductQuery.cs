using MediatR;
using StoreManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Application.Commands
{
    public class DeleteProductQuery : IRequest
    {
        public Guid Id { get; set; }
        public DeleteProductQuery(Guid id)
        {
            Id = id;
        }
    }
}
