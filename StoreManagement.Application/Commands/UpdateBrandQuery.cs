using MediatR;
using System;

namespace StoreManagement.Application.Commands
{
    public class UpdateBrandQuery : IRequest
    {
        public Guid Id { get; }
        public string Name { get; }
        public UpdateBrandQuery(Guid Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
