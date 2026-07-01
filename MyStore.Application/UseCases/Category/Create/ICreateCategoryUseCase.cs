using MyStore.Application.DTOs.Category;
using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Category.Create;

public interface ICreateCategoryUseCase
{
    Task<Result<CategoryDto>> ExecuteAsync(CategoryInputDto dto, CancellationToken ct = default);
}
