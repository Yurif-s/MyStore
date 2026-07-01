using MyStore.Application.Messages;
using MyStore.Domain.Exceptions;
using MyStore.Domain.Interfaces;

namespace MyStore.Application.UseCases.Product.Update;

public class UpdateStockUseCase(IProductRepository productRepository, IUnitOfWork unitOfWork) : IUpdateStockUseCase
{
    public async Task<Result> ExecuteAsync(int id, int quantity, CancellationToken ct = default)
    {
        var product = await productRepository.GetByIdAsync(id, ct);

        if (product is null)
            return Result.NotFound(ResourceErrorMessages.PRODUCT_NOT_FOUND);

        try
        {
            product.UpdateStock(quantity);
        }
        catch (DomainException ex)
        {
            return Result.ValidationError(ex.Message);
        }

        productRepository.Update(product);
        await unitOfWork.CommitAsync(ct);

        return Result.Success();
    }
}
