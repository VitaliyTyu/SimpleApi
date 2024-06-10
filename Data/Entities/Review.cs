/// <summary>
/// Represents a review made by a user for a product.
/// </summary>
public class Review
{
    /// <summary>
    /// Gets or sets the unique identifier for the review.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the user identifier who made the review.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets the user who made the review.
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Gets or sets the product identifier being reviewed.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the product being reviewed.
    /// </summary>
    public Product Product { get; set; }

    /// <summary>
    /// Gets or sets the rating given by the user.
    /// </summary>
    public int Rating { get; set; }

    /// <summary>
    /// Gets or sets the comment given by the user.
    /// </summary>
    public string Comment { get; set; }
}