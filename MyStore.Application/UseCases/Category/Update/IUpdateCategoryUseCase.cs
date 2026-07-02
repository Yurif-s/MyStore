using MyStore.Application.DTOs.Category;
using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Category.Update;

public interface IUpdateCategoryUseCase
{
    Task<Result<CategoryDto>> ExecuteAsync(int id, CategoryInputDto dto, CancellationToken ct = default);
}
