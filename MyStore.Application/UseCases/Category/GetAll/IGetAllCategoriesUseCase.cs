using MyStore.Application.DTOs.Category;
using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Category.GetAll;

public interface IGetAllCategoriesUseCase
{
    public Task<Result<List<CategoryDto>>> ExecuteAsync(CancellationToken ct = default);
}
