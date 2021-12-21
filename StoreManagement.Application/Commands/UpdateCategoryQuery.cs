using MediatR;
using StoreManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Application.Commands
{
    public class UpdateCategoryQuery : IRequest
    {
        public Guid Id { get; }
        public string Name { get; }
        public UpdateCategoryQuery(Guid Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
