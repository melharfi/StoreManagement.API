using MediatR;
using StoreManagement.Domain;
using System;

namespace StoreManagement.Application.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDetails>
    {
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
