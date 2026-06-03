namespace MyStore.Domain.Entities;

public class ProductImage
{
    public int Id { get; private set; }
    public int ProductId { get; private set; }
    public string Url { get; private set; } = string.Empty;
    public bool IsPrimary { get; private set; }
    public int DisplayOrder { get; private set; }

    protected ProductImage() { }

    public ProductImage(int productId, string url, bool isPrimary = false, int displayOrder = 0)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(url);
        ProductId = productId;
        Url = url;
        IsPrimary = isPrimary;
        DisplayOrder = displayOrder;
    }
}
