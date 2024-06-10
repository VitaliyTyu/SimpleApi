/// <summary>
/// Represents the inventory of a product in a warehouse.
/// </summary>
public class Inventory
{
    /// <summary>
    /// Gets or sets the unique identifier for the inventory.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the product identifier for this inventory.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the product associated with this inventory.
    /// </summary>
    public Product Product { get; set; }

    /// <summary>
    /// Gets or sets the warehouse identifier for this inventory.
    /// </summary>
    public int WarehouseId { get; set; }

    /// <summary>
    /// Gets or sets the warehouse associated with this inventory.
    /// </summary>
    public Warehouse Warehouse { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product in this inventory.
    /// </summary>
    public int Quantity { get; set; }
}