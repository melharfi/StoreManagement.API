using MediatR;
using StoreManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Application.Commands
{
    public class UpdateProductQuery : IRequest
    {
        public Guid Id { get; }
        public string Name { get; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public UpdateProductQuery(Guid Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
