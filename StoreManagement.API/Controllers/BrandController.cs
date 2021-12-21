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

        #region Gets
        [HttpGet(Name = nameof(GetAllBrandsAsync))]
        [SwaggerOperation(Summary = "Get All Brands", Description = "Get names of all Brands")]
        public async Task<ActionResult<List<Brand>>> GetAllBrandsAsync()
        {
            return await mediator.Send(new GetAllBrandsQuery());
        }
        #endregion

        #region Post
        [HttpPost(Name = nameof(PostBrandAsync))]
        [SwaggerOperation(Summary = "Post Brand", Description = "Post new instance of Brand")]
        public async Task<ActionResult<Guid>> PostBrandAsync([FromBody] CreateBrand dto)
        {
            try
            {
                Guid id = await mediator.Send(new CreateBrandQuery(dto.Name));
                return Ok(id);
            }
            catch(BrandNameDuplicationException)
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
        [HttpPut(Name = nameof(PutBrandAsync))]
        [SwaggerOperation(Summary = "Post Brand", Description = "Post new instance of Brand")]
        public async Task<ActionResult> PutBrandAsync([FromBody] UpdateBrand dto)
        {
            try
            {
                await mediator.Send(new UpdateBrandQuery(dto.Id, dto.Name));
                return Ok();
            }
            catch(BrandNotFoundException)
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
        [HttpDelete(Name = nameof(DeleteBrandAsync))]
        [SwaggerOperation(Summary = "Delete Brand", Description = "Delete new instance of Brand")]
        public async Task<ActionResult> DeleteBrandAsync([FromBody] DeleteBrand dto)
        {
            try
            {
                await mediator.Send(new DeleteBrandQuery(dto.Id));
                return Ok();
            }
            catch (BrandNotFoundException)
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
