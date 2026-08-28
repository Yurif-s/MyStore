using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyStore.Application.DTOs.Category;
using MyStore.Application.Messages;
using MyStore.Application.UseCases.Category.Create;
using MyStore.Application.UseCases.Category.GetAll;
using MyStore.Application.UseCases.Category.Update;

namespace MyStore.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] ICreateCategoryUseCase useCase,
        [FromBody] CategoryInputDto dto,
        CancellationToken ct)
    {
        var result = await useCase.ExecuteAsync(dto, ct);

        return result.Status switch
        {
            ResultStatus.ValidationError => BadRequest(result.Errors),
            ResultStatus.Conflict => Conflict(result.Errors),
            _ => Created(string.Empty, result.Value)
        };
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromServices] IGetAllCategoriesUseCase useCase,
        CancellationToken ct)
    {
        var result = await useCase.ExecuteAsync(ct);

        return result.Status switch
        {
            ResultStatus.NoContent => NoContent(),
            _ => Ok(result)
        };
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update(
        [FromRoute] int id,
        [FromBody] CategoryInputDto dto,
        [FromServices] IUpdateCategoryUseCase useCase,
        CancellationToken ct)
    {
        var result = await useCase.ExecuteAsync(id, dto, ct);

        return result.Status switch
        {
            ResultStatus.ValidationError => BadRequest(result.Errors),
            ResultStatus.Conflict => Conflict(result.Errors),
            _ => Ok(result.Value)
        };
    }
}
