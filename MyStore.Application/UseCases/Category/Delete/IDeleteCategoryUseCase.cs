using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Category.Delete;

public interface IDeleteCategoryUseCase
{
    Task<Result> ExecuteAsync(int id, CancellationToken ct);
}
