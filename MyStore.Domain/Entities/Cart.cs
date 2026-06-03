using MyStore.Domain.Exceptions;

namespace MyStore.Domain.Entities;

public class Cart
{
    public int Id { get; private set; }
    public string UserId { get; private set; } = string.Empty;

    private readonly List<CartItem> _items = [];
    public IReadOnlyCollection<CartItem> Items => _items;

    public decimal Total => _items.Sum(i => i.Subtotal);

    protected Cart() { }

    public Cart(string userId) => UserId = userId;

    public void AddItem(Product product, int quantity)
    {
        if (!product.IsActive) throw new DomainException("Product is unavailable.");
        if (quantity > product.Stock) throw new DomainException("Insufficient stock.");

        var existingItem = _items.FirstOrDefault(i => i.ProductId == product.Id);
        if (existingItem is not null)
            existingItem.UpdateQuantity(existingItem.Quantity + quantity);
        else
            _items.Add(new CartItem(product.Id, product.Price, quantity));
    }

    public void RemoveItem(int productId)
    {
        var item = _items.FirstOrDefault(i => i.ProductId == productId)
            ?? throw new DomainException("Item not found in cart.");
        _items.Remove(item);
    }

    public void Clear() => _items.Clear();
}