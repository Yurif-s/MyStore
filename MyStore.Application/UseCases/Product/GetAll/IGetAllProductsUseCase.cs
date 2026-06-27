using MyStore.Application.DTOs.Product;
using MyStore.Application.Messages;

namespace MyStore.Application.UseCases.Product.GetAll;

public interface IGetAllProductsUseCase
{
    public Task<Result<List<ProductDto>>> ExecuteAsync(CancellationToken ct = default);
}
