using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreManagement.Application.Queries;
using StoreManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly IMediator mediator;

        public BrandController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Brand>> GetAll()
        {
            return await mediator.Send(new GetAllBrandsQuery());
        }

        
    }
}
