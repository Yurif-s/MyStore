using MyStore.Domain.Exceptions;

namespace MyStore.Domain.Entities;

public class CartItem
{
    public int Id { get; private set; }
    public int CartId { get; private set; }
    public int ProductId { get; private set; }
    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }
    public decimal Subtotal => UnitPrice * Quantity;

    protected CartItem() { }

    public CartItem(int cartId, int productId, decimal unitPrice, int quantity)
    {
        if (unitPrice <= 0) throw new DomainException("Unit price must be positive.");
        if (quantity <= 0) throw new DomainException("Quantity must be greater than zero.");

        CartId = cartId;
        ProductId = productId;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

    public void UpdateQuantity(int newQuantity)
    {
        if (newQuantity <= 0) throw new DomainException("Quantity must be greater than zero.");
        Quantity = newQuantity;
    }
}