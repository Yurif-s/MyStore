namespace MyStore.Application.DTOs.Product;

public record ProductDto(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int Stock,
    bool IsActive,
    int CategoryId,
    string CategoryName
);
