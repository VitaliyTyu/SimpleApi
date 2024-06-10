/// <summary>
/// Represents a brand.
/// </summary>
public class Brand
{
    /// <summary>
    /// Gets or sets the unique identifier for the brand.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the brand.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the collection of products associated with this brand.
    /// </summary>
    public ICollection<Product> Products { get; set; }
}