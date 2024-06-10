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
    /// Gets or sets the collection of products associated with this product info.
    /// </summary>
    public ICollection<Product> Products { get; set; }

    /// <summary>
    /// Gets or sets the collection of product info categories associated with this product info.
    /// </summary>
    public ICollection<ProductInfo> ProductInfos { get; set; }
}