/// <summary>
/// Represents the status of an order.
/// </summary>
public class OrderStatus
{
    /// <summary>
    /// Gets or sets the unique identifier for the order status.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the status description.
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Gets or sets the collection of orders associated with this status.
    /// </summary>
    public ICollection<Order> Orders { get; set; }
}