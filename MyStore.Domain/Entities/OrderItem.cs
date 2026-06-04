using MyStore.Domain.Exceptions;

namespace MyStore.Domain.Entities;

public class OrderItem
{
    public int Id { get; private set; }
    public int OrderId { get; private set; }
    public int ProductId { get; private set; }
    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }
    public decimal Subtotal => UnitPrice * Quantity;

    protected OrderItem() { }

    public OrderItem(int orderId, int productId, decimal unitPrice, int quantity)
    {
        if (unitPrice <= 0) throw new DomainException("Unit price must be positive.");
        if (quantity <= 0) throw new DomainException("Quantity must be greater than zero.");

        OrderId = orderId;
        ProductId = productId;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }
}
