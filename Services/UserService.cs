using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
public interface IUserService
{
    Task<User> RegisterAsync(User user, string password);
    Task<string> AuthenticateAsync(string username, string password);
}



public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public UserService(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

   public async Task<User> RegisterAsync(User user, string password)
    {
        // Add user registration logic here, e.g., hashing the password
        // and storing the user in the database.
        // For simplicity, assuming password is stored as plain text.
        user.Password = password;
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<string> AuthenticateAsync(string username, string password)
    {
        // Add user authentication logic here.
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        if (user == null) return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
