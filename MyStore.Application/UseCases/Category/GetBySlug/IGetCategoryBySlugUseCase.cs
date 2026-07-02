using MyStore.Application.DTOs.Category;
using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Category.GetBySlug;

public interface IGetCategoryBySlugUseCase
{
    public Task<Result<CategoryDto>> ExecuteAsync(string slug, CancellationToken ct = default);
}
