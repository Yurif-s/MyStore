using MyStore.Application.DTOs.Product;
using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Product.GetById;

public interface IGetProductByIdUseCase
{
    public Task<Result<ProductDto>> ExecuteAsync(int id, CancellationToken ct = default);
}
