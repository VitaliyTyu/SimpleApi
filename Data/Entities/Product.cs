/// <summary>
/// Represents a product.
/// </summary>
public class Product
{
    /// <summary>
    /// Gets or sets the unique identifier for the product.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the product info identifier.
    /// </summary>
    public int ProductInfoId { get; set; }

    /// <summary>
    /// Gets or sets the product info associated with this product.
    /// </summary>
    public ProductInfo ProductInfo { get; set; }

    /// <summary>
    /// Gets or sets the collection of reviews for this product.
    /// </summary>
    public ICollection<Review> Reviews { get; set; }

    /// <summary>   
    /// Gets or sets the collection of inventories for this product.
    /// </summary>
    public ICollection<Inventory> Inventories { get; set; }
            
    /// <summary>
    /// Gets or sets the collection of order items for this product.
    /// </summary>
    public ICollection<OrderItem> OrderItems { get; set; }


    /// <summary>
    /// Gets or sets the discount identifier.
    /// </summary>
    public int DiscountId { get; set; }

    /// <summary>
    /// Gets or sets the discount.
    /// </summary>
    public Discount Discount { get; set; }
}