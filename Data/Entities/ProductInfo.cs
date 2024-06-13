/// <summary>
/// Represents additional information about a product.
/// </summary>
public class ProductInfo
{
    /// <summary>
    /// Gets or sets the unique identifier for the product info.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the description of the product info.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the product identifier.
    /// </summary>
    public int ProducId { get; set; }

    /// <summary>
    /// Gets or sets the product.
    /// </summary>
    public Product Product { get; set; }

    /// <summary>
    /// Gets or sets the brand identifier for the product.
    /// </summary>
    public int BrandId { get; set; }

    /// <summary>
    /// Gets or sets the brand associated with this product.
    /// </summary>
    public Brand Brand { get; set; }
}