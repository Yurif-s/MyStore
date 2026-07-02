using MyStore.Application.DTOs.Category;
using MyStore.Application.Messages;
using MyStore.Domain.Interfaces;

namespace MyStore.Application.UseCases.Category.GetAll;

public class GetAllCategoriesUseCase(
    ICategoryRepository categoryRepository) : IGetAllCategoriesUseCase
{
    public async Task<Result<List<CategoryDto>>> ExecuteAsync(CancellationToken ct = default)
    {
        var categories = await categoryRepository.GetAllAsync(ct);

        if (!categories.Any())
            return Result<List<CategoryDto>>.NoContent();

        var response = categories.Select(c => new CategoryDto(
            c.Name,
            c.Slug)).ToList();

        return Result<List<CategoryDto>>.Success(response);
    }
}
