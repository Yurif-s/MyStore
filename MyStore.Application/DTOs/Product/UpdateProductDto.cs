namespace MyStore.Application.DTOs.Product;

public record UpdateProductDto(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int CategoryId
);
