using MediatR;
using StoreManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Application.Commands
{
    public class DeleteBrandQuery : IRequest
    {
        public Guid Id { get; set; }
        public DeleteBrandQuery(Guid id)
        {
            Id = id;
        }
    }
}
