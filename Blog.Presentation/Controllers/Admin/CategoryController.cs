using System.Net;
using Blog.Application.CQRS.Command.Category.DeleteCategory;
using Blog.Application.CQRS.Command.Category.InsertCategory;
using Blog.Application.CQRS.Command.Category.UpdateCategory;
using Blog.Application.CQRS.Query.Category.AllCategory;
using Blog.Application.CQRS.Query.Category.CategoryById;
using Blog.Data.Results;
using Blog.Infrastructure.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Controllers.Admin;

[ApiExplorerSettings(GroupName = "Admin-v1")]
public class CategoryController : ControllerBase
{
   private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(AdminRoutes.Category.Insert)]
    [ProducesResponseType(typeof(ApiBaseResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiErrorResult), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Insert([FromBody] InsertCategoryDto entry)
    {
        var result = await _mediator.Send<ServiceResult<string>>(entry);
        if (!result.Success)
        {
            return BadRequest(new ApiErrorResult(result.Message));
        }

        return Ok(new ApiBaseResult());
    }


    [HttpPost(AdminRoutes.Category.Update)]
    [ProducesResponseType(typeof(ApiBaseResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiErrorResult), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryDto entry)
    {
        var result = await _mediator.Send<ServiceResult<string>>(entry);
        if (!result.Success)
        {
            return BadRequest(new ApiErrorResult(result.Message));
        }

        return Ok(new ApiBaseResult());
    }


    [HttpDelete(AdminRoutes.Category.Delete)]
    [ProducesResponseType(typeof(ApiBaseResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiErrorResult), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Delete([FromRoute] DeleteCategoryDto entry)
    {
        var result = await _mediator.Send<ServiceResult<string>>(entry);
        if (!result.Success)
        {
            return BadRequest(new ApiErrorResult(result.Message));
        }

        return Ok(new ApiBaseResult());
    }

    [HttpGet(AdminRoutes.Category.GetAll)]
    [ProducesResponseType(typeof(ApiResult<List<AllCategoryResultDto>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send<List<AllCategoryResultDto>>(new AllCategoryDto());
        if (!result.Any())
        {
            return NoContent();
        }

        return Ok(new ApiResult<List<AllCategoryResultDto>>()
        {
            Result = result
        });
    }


    [HttpGet(AdminRoutes.Category.Get)]
    [ProducesResponseType(typeof(ApiResult<CategoryByIdResultDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetById([FromRoute] CategoryByIdDto entry)
    {
        var result = await _mediator.Send<CategoryByIdResultDto>(entry);
        if (result == null)
        {
            return NoContent();
        }

        return Ok(new ApiResult<CategoryByIdResultDto>()
        {
            Result = result
        });
    }
}