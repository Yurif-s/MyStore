using MyStore.Application.Messages;
using MyStore.Domain.Interfaces;

namespace MyStore.Application.UseCases.Product.Activate;

public class DeactivateProductUseCase(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) : IDeactivateProductUseCase
{
    public async Task<Result> ExecuteAsync(int id, CancellationToken ct = default)
    {
        var product = await productRepository.GetByIdAsync(id, ct);

        if (product is null)
            return Result.NotFound(ResourceErrorMessages.PRODUCT_NOT_FOUND);

        product.Deactivate();
        productRepository.Update(product);
        await unitOfWork.CommitAsync(ct);

        return Result.Success();
    }
}
