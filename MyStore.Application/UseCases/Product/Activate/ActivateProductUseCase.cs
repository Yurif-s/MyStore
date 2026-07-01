using MyStore.Application.Messages;
using MyStore.Domain.Interfaces;

namespace MyStore.Application.UseCases.Product.Activate;

public class ActivateProductUseCase(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork) : IActivateProductUseCase
{
    public async Task<Result> ExecuteAsync(int id, CancellationToken ct = default)
    {
        var product = await productRepository.GetByIdAsync(id, ct);

        if (product is null)
            return Result.NotFound(ResourceErrorMessages.PRODUCT_NOT_FOUND);

        product.Activate();
        productRepository.Update(product);
        await unitOfWork.CommitAsync(ct);

        return Result.Success();
    }
}
