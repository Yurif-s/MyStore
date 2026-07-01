using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Product.Activate;

public interface IDeactivateProductUseCase
{
    Task<Result> ExecuteAsync(int id, CancellationToken ct = default);
}
