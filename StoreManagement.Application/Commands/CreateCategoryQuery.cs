using MediatR;
using StoreManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Application.Commands
{
    public class CreateCategoryQuery : IRequest<Guid>
    {
        public string Name { get; set; }
        public CreateCategoryQuery(string name)
        {
            Name = name;
        }
    }
}
