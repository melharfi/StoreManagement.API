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
    public class CategoriesController : Controller
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region Gets
        [HttpGet(Name = nameof(GetCategoriesPaginationAsync))]
        [SwaggerOperation(Summary = "Get Categories by pagination", Description = "Get Categories by elementCount and starting from pageIndex offset")]
        public async Task<ActionResult<CategoryPagination>> GetCategoriesPaginationAsync([FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 10)
        {
            if (pageIndex == 0)
            {
                ModelState.AddModelError("pageSize", "Should be greater than 0");
                return BadRequest(ModelState);
            }
            return await mediator.Send(new GetCategoriesPaginationQuery(pageIndex, pageSize));
        }
        #endregion

        #region Post
        [HttpPost(Name = nameof(PostCategoryAsync))]
        [SwaggerOperation(Summary = "Post Category", Description = "Post new instance of Category")]
        public async Task<ActionResult<Guid>> PostCategoryAsync([FromBody] CreateCategory dto)
        {
            try
            {
                Guid id = await mediator.Send(new CreateCategoryQuery(dto.Name));
                return Ok(id);
            }
            catch (CategoryNameDuplicationException)
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
        [HttpPut(Name = nameof(PutCategoryAsync))]
        [SwaggerOperation(Summary = "Post Category", Description = "Post new instance of Category")]
        public async Task<ActionResult> PutCategoryAsync([FromBody] UpdateCategory dto)
        {
            try
            {
                await mediator.Send(new UpdateCategoryQuery(dto.Id, dto.Name));
                return Ok();
            }
            catch (CategoryNotFoundException)
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
        [HttpDelete("{id}", Name = nameof(DeleteCategoryByIdAsync))]
        [SwaggerOperation(Summary = "Delete Category by Id", Description = "Delete Category by Id as GUID")]
        public async Task<ActionResult> DeleteCategoryByIdAsync(Guid id)
        {
            try
            {
                await mediator.Send(new DeleteCategoryQuery(id));
                return Ok();
            }
            catch (CategoryNotFoundException)
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
