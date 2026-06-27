using MyStore.Application.DTOs.Product;
using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Product.Update;

public interface IUpdateProductUseCase
{
    Task<Result<ProductDto>> ExecuteAsync(UpdateProductDto dto, CancellationToken ct = default);
}
