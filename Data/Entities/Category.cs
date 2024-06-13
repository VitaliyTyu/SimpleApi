/// <summary>
/// Represents a product category.
/// </summary>
public class Category
{
    /// <summary>
    /// Gets or sets the unique identifier for the category.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the category.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets description of the category.
    /// </summary>
    public string Description { get; set; }


    /// <summary>
    /// Gets or sets the collection of product infos associated with this category.
    /// </summary>
    public ICollection<ProductInfo> ProductInfos { get; set; }
}
