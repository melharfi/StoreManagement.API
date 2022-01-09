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
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public CreateProductQuery(string name, Guid brandId, Guid categoryId, string description, decimal price)
        {
            Name = name;
            CategoryId = categoryId;
            BrandId = brandId;
            Description = description;
            Price = price;
        }
    }
}
