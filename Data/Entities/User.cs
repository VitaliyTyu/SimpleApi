/// <summary>
/// Represents a user in the system.
/// </summary>
public class User
{
    /// <summary>
    /// Gets or sets the unique identifier for the user.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets the email of the user.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the phone of the user.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Gets or sets the addres of the user.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Gets or sets the collection of user roles for this user.
    /// </summary>
    public ICollection<Role> Roles { get; set; } = new List<Role>();

    /// <summary>
    /// Gets or sets the collection of orders placed by this user.
    /// </summary>
    public ICollection<Order> Orders { get; set; } = new List<Order>();

    /// <summary>
    /// Gets or sets the collection of reviews made by this user.
    /// </summary>
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}

