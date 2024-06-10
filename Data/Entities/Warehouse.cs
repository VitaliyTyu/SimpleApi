/// <summary>
/// Represents a warehouse.
/// </summary>
public class Warehouse
{
    /// <summary>
    /// Gets or sets the unique identifier for the warehouse.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the location of the warehouse.
    /// </summary>
    public string Location { get; set; }

    /// <summary>
    /// Gets or sets the collection of inventories in this warehouse.
    /// </summary>
    public ICollection<Inventory> Inventories { get; set; }
}