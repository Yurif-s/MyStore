using MyStore.Application.DTOs.Product;
using MyStore.Application.Messages;
using MyStore.Domain.Interfaces;

namespace MyStore.Application.UseCases.Product.GetById;

public class GetProductByIdUseCase(
    IProductRepository productRepository,
    ICategoryRepository categoryRepository) : IGetProductByIdUseCase
{
    public async Task<Result<ProductDto>> ExecuteAsync(int id, CancellationToken ct = default)
    {
        var product = await productRepository.GetByIdAsync(id, ct);

        if (product is null)
            return Result<ProductDto>.NotFound(ResourceErrorMessages.PRODUCT_NOT_FOUND);

        var category = await categoryRepository.GetByIdAsync(product.CategoryId, ct);
        if (category is null)
            return Result<ProductDto>.NotFound(ResourceErrorMessages.CATEGORY_NOT_FOUND);

        var response = new ProductDto(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.Stock,
            product.IsActive,
            product.CategoryId,
            category.Name);

        return Result<ProductDto>.Success(response);
    }
}
