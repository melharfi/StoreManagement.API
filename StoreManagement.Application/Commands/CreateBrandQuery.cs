using MediatR;
using StoreManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Application.Commands
{
    public class CreateBrandQuery : IRequest<Guid>
    {
        public string Name { get; set; }
        public CreateBrandQuery(string name)
        {
            Name = name;
        }
    }
}
