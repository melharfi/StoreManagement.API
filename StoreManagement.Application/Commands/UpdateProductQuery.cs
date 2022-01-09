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
        public Guid BrandId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public UpdateProductQuery(Guid id, string name, Guid brandId, Guid categoryId, string description, decimal price)
        {
            Id = id;
            Name = name;
            BrandId = brandId;
            CategoryId = categoryId;
            Description = description;
            Price = price;
        }
    }
}
