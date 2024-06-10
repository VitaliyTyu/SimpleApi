/// <summary>
/// Represents an order placed by a user.
/// </summary>
public class Order
{
    /// <summary>
    /// Gets or sets the unique identifier for the order.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the user identifier who placed the order.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets the user who placed the order.
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Gets or sets the order status identifier.
    /// </summary>
    public int OrderStatusId { get; set; }

    /// <summary>
    /// Gets or sets the order status.
    /// </summary>
    public OrderStatus OrderStatus { get; set; }

    /// <summary>
    /// Gets or sets the collection of order items in this order.
    /// </summary>
    public ICollection<OrderItem> OrderItems { get; set; }
}