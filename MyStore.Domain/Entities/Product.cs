using MyStore.Domain.Exceptions;

namespace MyStore.Domain.Entities;

public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public bool IsActive { get; private set; } = true;
    public int CategoryId { get; private set; }
    public Category Category { get; private set; } = null!;

    private readonly List<ProductImage> _images = [];
    public IReadOnlyCollection<ProductImage> Images => _images;

    protected Product() { }

    public Product(string name, string description, decimal price, int stock, int categoryId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        if (price <= 0) throw new DomainException("Price must be positive.");
        if (stock < 0) throw new DomainException("Stock cannot be negative.");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        CategoryId = categoryId;
    }

    public void UpdateStock(int quantity)
    {
        if (Stock + quantity < 0)
            throw new DomainException("Insufficient stock.");
        Stock += quantity;
    }

    public void AddImage(string url, bool isPrimary = false)
    {
        if (isPrimary && _images.Any(i => i.IsPrimary))
            throw new DomainException("A primary image already exists.");

        _images.Add(new ProductImage(Id, url, isPrimary, _images.Count));
    }

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;
}