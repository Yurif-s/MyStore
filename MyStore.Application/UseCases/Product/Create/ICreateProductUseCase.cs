using MyStore.Application.DTOs.Product;
using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Product.Create;

public interface ICreateProductUseCase
{
    Task<Result<ProductDto>> ExecuteAsync(CreateProductDto dto, CancellationToken ct = default);
}
