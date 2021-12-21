using MediatR;
using StoreManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Application.Commands
{
    public class CreateProductQuery : IRequest<Guid>
    {
        public string Name { get; set; }
        public CreateProductQuery(string name)
        {
            Name = name;
        }
    }
}
