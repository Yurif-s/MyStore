using MyStore.Application.DTOs.Product;
using MyStore.Application.Messages;
using MyStore.Domain.Interfaces;

namespace MyStore.Application.UseCases.Product.GetAll;

public class GetAllProductsUseCase(
    IProductRepository productRepository,
    ICategoryRepository categoryRepository) : IGetAllProductsUseCase
{
    public async Task<Result<List<ProductDto>>> ExecuteAsync(CancellationToken ct = default)
    {
        var products = await productRepository.GetAllAsync(ct);

        if (!products.Any())
            return Result<List<ProductDto>>.NoContent();

        var categoryIds = products.Select(p => p.CategoryId).Distinct().ToList();

        var categories = await categoryRepository.GetByIdsAsync(categoryIds, ct);
        var categoryMap = categories.ToDictionary(c => c.Id, c => c.Name);

        var response = products.Select(p => new ProductDto(
            p.Id,
            p.Name,
            p.Description,
            p.Price,
            p.Stock,
            p.IsActive,
            p.CategoryId,
            categoryMap.GetValueOrDefault(p.CategoryId, string.Empty)
        )).ToList();

        return Result<List<ProductDto>>.Success(response);
    }
}
