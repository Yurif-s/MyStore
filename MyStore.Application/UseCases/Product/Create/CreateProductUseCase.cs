using MyStore.Application.DTOs.Product;
using MyStore.Application.Messages;
using MyStore.Domain.Interfaces;
using Mapster;

namespace MyStore.Application.UseCases.Product.Create;

public class CreateProductUseCase(
    IProductRepository productRepository,
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) : ICreateProductUseCase
{

    public async Task<Result<ProductDto>> ExecuteAsync(CreateProductDto dto, CancellationToken ct = default)
    {
        var validationResult = await new CreateProductValidator().ValidateAsync(dto, ct);
        if (!validationResult.IsValid)
            return Result<ProductDto>.ValidationError (
                validationResult.Errors.Select(e => e.ErrorMessage));

        var category = await categoryRepository.GetByIdAsync(dto.CategoryId, ct);
        if (category is null)
            return Result<ProductDto>.NotFound(ResourceErrorMessages.CATEGORY_NOT_FOUND);

        var product = new Domain.Entities.Product(dto.Name, dto.Description, dto.Price, dto.Stock, dto.CategoryId);

        await productRepository.AddAsync(product, ct);
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
