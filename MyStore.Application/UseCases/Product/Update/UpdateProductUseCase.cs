using MyStore.Application.DTOs.Product;
using MyStore.Application.Messages;
using MyStore.Domain.Interfaces;

namespace MyStore.Application.UseCases.Product.Update;

public class UpdateProductUseCase(IProductRepository productRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : IUpdateProductUseCase
{
    public async Task<Result<ProductDto>> ExecuteAsync(UpdateProductDto dto, CancellationToken ct = default)
    {
        var validationResult = await new UpdateProductValidator().ValidateAsync(dto, ct);
        if (!validationResult.IsValid)
            return Result<ProductDto>.ValidationError(
                validationResult.Errors.Select(e => e.ErrorMessage));

        var product = await productRepository.GetByIdAsync(dto.Id, ct);

        if (product is null)
            return Result<ProductDto>.NotFound(ResourceErrorMessages.PRODUCT_NOT_FOUND);

        var category = await categoryRepository.GetByIdAsync(dto.CategoryId, ct);

        if (category is null)
            return Result<ProductDto>.NotFound(ResourceErrorMessages.CATEGORY_NOT_FOUND);

        product.Update(dto.Name, dto.Description, dto.Price, dto.CategoryId);

        productRepository.Update(product);
        await unitOfWork.CommitAsync(ct);

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
