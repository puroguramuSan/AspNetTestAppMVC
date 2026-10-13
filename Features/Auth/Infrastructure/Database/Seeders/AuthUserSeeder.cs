using Microsoft.AspNetCore.Identity;
using AspNetTestAppMVC.Features.Auth.Infrastructure.Database.Models;

public class AuthUserSeeder(
    AuthUserFactory authUserFactory,
    UserManager<AuthUser> userManager,
    ILogger<AuthUserSeeder> logger
)
{
  private readonly AuthUserFactory _factory = authUserFactory;
  private readonly UserManager<AuthUser> _userManager = userManager;
  private readonly ILogger<AuthUserSeeder> _logger = logger;

  public async Task SeedAsync(int count = 25)
  {
    if (_userManager.Users.Any()) {
      _logger.LogInformation("Users already seeded");
      return;
    }

    await CreateTestAdminAsync();
    await CreateTestUserAsync();

    for(var i = 0; i < count; i++) {
      await _factory.CreateAsync(password: "Test123!");
    }
  }

  public async Task CreateTestAdminAsync()
  {
    var admin = await _userManager.FindByNameAsync("admin");
    var exists = admin is not null;
    if (exists) {
      _logger.LogInformation("Admin user already exists");
      return;
    }

    await _factory.CreateAsync(
        password: "AdminPass123!",
        configure: u =>
        {
          u.UserName = "admin";
          u.Email = "admin@example.com";
          u.EmailConfirmed = true;
        }
        );
  }

  public async Task CreateTestUserAsync()
  {
    var user = await _userManager.FindByNameAsync("user");

    var exists = user is not null;
    if (exists) {
      _logger.LogInformation("Test user already exits");
      return;
    }

    await _factory.CreateAsync(
      password: "UserPass123!",
      configure: u => {
        u.UserName = "user";
        u.Email = "user@example.com";
        u.EmailConfirmed = true;
      }
    );
  }
}
