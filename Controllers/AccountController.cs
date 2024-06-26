using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Registers a new user.
    /// </summary>
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegistrationDto registrationDto, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserName = registrationDto.UserName,
        };
        var token = await _userService.RegisterAsync(user, registrationDto.Password, registrationDto.Role, cancellationToken);
        return Ok(token);
    }

    /// <summary>
    /// Authenticates a user and returns a JWT token.
    /// </summary>
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto loginDto, CancellationToken cancellationToken)
    {
        var token = await _userService.AuthenticateAsync(loginDto.UserName, loginDto.Password, cancellationToken);
        if (token == null)
        {
            return Unauthorized();
        }
        return Ok(new { Token = token });
    }
}
