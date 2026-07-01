using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Product.Update;

public interface IUpdateStockUseCase
{
    Task<Result> ExecuteAsync(int id, int quantity, CancellationToken ct = default);
}
