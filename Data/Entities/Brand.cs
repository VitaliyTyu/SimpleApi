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
    /// Gets or sets the name of the description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the name of the country.
    /// </summary>
    public string Country  { get; set;  }

    /// <summary>
    /// Gets or sets the collection of product info categories associated with this product info.
    /// </summary>
    public ICollection<ProductInfo> ProductInfos { get; set; }
}