namespace MyStore.Application.DTOs.Product;

public record GetAllProductsDto(
    string? SearchTerm,
    int? CategoryId
);
