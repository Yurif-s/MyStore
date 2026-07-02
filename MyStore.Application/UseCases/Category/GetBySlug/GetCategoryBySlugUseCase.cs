using MyStore.Application.DTOs.Category;
using MyStore.Application.Messages;
using MyStore.Domain.Interfaces;

namespace MyStore.Application.UseCases.Category.GetBySlug;

public class GetCategoryBySlugUseCase(ICategoryRepository categoryRepository) : IGetCategoryBySlugUseCase
{
    public async Task<Result<CategoryDto>> ExecuteAsync(string slug, CancellationToken ct = default)
    {
        var category = await categoryRepository.GetBySlugAsync(slug, ct);

        if (category is null)
            return Result<CategoryDto>.NotFound(ResourceErrorMessages.CATEGORY_NOT_FOUND);

        var response = new CategoryDto(category.Name, category.Slug);

        return Result<CategoryDto>.Success(response);
    }
}
