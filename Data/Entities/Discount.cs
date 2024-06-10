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
    /// Gets or sets the discount amount.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the collection of products associated with this discount.
    /// </summary>
    public ICollection<Product> Products { get; set; }
}
