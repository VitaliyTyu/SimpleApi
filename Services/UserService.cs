using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Cryptography;

public interface IUserService
{
    Task<string> RegisterAsync(User user, string password, CancellationToken cancellationToken);
    Task<string> AuthenticateAsync(string username, string password, CancellationToken cancellationToken);
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

   public async Task<string> RegisterAsync(User user, string password, CancellationToken cancellationToken)
    {
        var hashedPassword  = CalculateMD5Hash(password);

        user.Password = hashedPassword;
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
        return CreateJwtToken(user);
    }

    public async Task<string> AuthenticateAsync(string username, string password, CancellationToken cancellationToken)
    {
        var hashedPassword  = CalculateMD5Hash(password);

        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == hashedPassword, cancellationToken);
        if (user == null) return null;

        return CreateJwtToken(user);
    }

    public string CreateJwtToken(User user)
    {
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

    public string CalculateMD5Hash(string input)
    {
        MD5 md5 = MD5.Create();
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);
        byte[] hash = md5.ComputeHash(inputBytes);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        return sb.ToString();
    }
}
