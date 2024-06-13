/// <summary>
/// Represents a discount code.
/// </summary>
public class Discount
{
    /// <summary>
    /// Gets or sets the unique identifier for the discount.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the discount code.
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets the discount percentage.
    /// </summary>
    public decimal DiscountPercentage { get; set; }

    /// <summary>
    /// Gets or sets start date.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Gets or sets end date.
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Gets or sets the collection of products associated with this discount.
    /// </summary>
    public ICollection<Product> Products { get; set; }

    /// <summary>
    /// Gets or sets the collection of orders.
    /// </summary>
    public ICollection<Order> Orders { get; set; }
}
