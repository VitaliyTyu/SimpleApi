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
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the collection of orders associated with this status.
    /// </summary>
    public ICollection<Order> Orders { get; set; }
}