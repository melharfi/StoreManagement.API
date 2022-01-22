using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreManagement.API.DTOs;
using StoreManagement.Application.Commands;
using StoreManagement.Application.Exceptions;
using StoreManagement.Application.Queries;
using StoreManagement.Domain;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region Gets
        [HttpGet("{id}", Name = nameof(GetProductByIdAsync))]
        [SwaggerOperation(Summary = "Get products by pagination", Description = "Get Products by elementCount and starting from pageIndex offset")]
        public async Task<ActionResult<ProductDetails>> GetProductByIdAsync(Guid id)
        {
            ProductDetails readingProduct = await mediator.Send(new GetProductByIdQuery(id));
            if (readingProduct == null)
                return NotFound();
            else
                return readingProduct;
        }

        [HttpGet("pagination", Name = nameof(GetProductsPaginationAsync))]
        [SwaggerOperation(Summary = "Get products by pagination", Description = "Get Products by elementCount and starting from pageIndex offset")]
        public async Task<ActionResult<ProductPagination>> GetProductsPaginationAsync(int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex == 0)
            {
                ModelState.AddModelError("pageSize", "Should be greater than 0");
                return BadRequest(ModelState);
            }
            return await mediator.Send(new GetProductsPaginationQuery(pageIndex, pageSize));
        }
        #endregion

        #region Post
        [HttpPost(Name = nameof(PostProductAsync))]
        [SwaggerOperation(Summary = "Post Product", Description = "Post new instance of Product")]
        public async Task<ActionResult<Guid>> PostProductAsync([FromBody] CreateProduct dto)
        {
            try
            {
                Guid id = await mediator.Send(new CreateProductQuery(dto.Name, dto.BrandId, dto.CategoryId, dto.Description, dto.Price));
                return Ok(id);
            }
            catch (ProductNameDuplicationException)
            {
                ModelState.AddModelError("Name", "DUPLICATION");
                return BadRequest(ModelState);
            }
            catch
            {
                ModelState.AddModelError("Error", "InternalError");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion

        #region Put
        [HttpPut(Name = nameof(PutProductAsync))]
        [SwaggerOperation(Summary = "Put Product", Description = "Edit a Product using Put verb")]
        public async Task<ActionResult> PutProductAsync([FromBody] UpdateProduct dto)
        {
            try
            {
                await mediator.Send(new UpdateProductQuery(dto.Id, dto.Name, dto.BrandId, dto.CategoryId, dto.Description, dto.Price));
                return Ok();
            }
            catch (ProductNotFoundException)
            {
                return NotFound();
            }
            catch
            {
                ModelState.AddModelError("Error", "InternalError");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion

        #region Delete
        [HttpDelete(("{id}"), Name = nameof(DeleteProductByIdAsync))]
        [SwaggerOperation(Summary = "Delete Product", Description = "Delete Product")]
        public async Task<ActionResult> DeleteProductByIdAsync(Guid id)
        {
            try
            {
                await mediator.Send(new DeleteProductQuery(id));
                return Ok();
            }
            catch (ProductNotFoundException)
            {
                return NotFound();
            }
            catch
            {
                ModelState.AddModelError("Error", "InternalError");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion
    }
}
