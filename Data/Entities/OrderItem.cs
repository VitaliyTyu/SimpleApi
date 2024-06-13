/// <summary>
/// Represents an item in an order.
/// </summary>
public class OrderItem
{
    /// <summary>
    /// Gets or sets the unique identifier for the order item.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the order identifier this item belongs to.
    /// </summary>
    public int OrderId { get; set; }

    /// <summary>
    /// Gets or sets the order this item belongs to.
    /// </summary>
    public Order Order { get; set; }

    /// <summary>
    /// Gets or sets the product identifier for this order item.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the product associated with this order item.
    /// </summary>
    public Product Product { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product in this order item.
    /// </summary>
    public int Quantity { get; set; }
}