using Bogus;
using Microsoft.AspNetCore.Identity;

using AspNetTestAppMVC.Features.Auth.Infrastructure.Database.Models;

public class AuthUserFactory(UserManager<AuthUser> userManager)
{

  private readonly UserManager<AuthUser> _userManager = userManager;
  private readonly Faker<AuthUser> _faker = new Faker<AuthUser>()
      .RuleFor(u => u.UserName, f => f.Internet.UserName() + Guid.NewGuid().ToString("N")[..8])
      .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.UserName))
      .RuleFor(u => u.EmailConfirmed, _ => true);

  public AuthUser Build(Action<AuthUser>? configure = null)
  {
    var user = _faker.Generate();
    configure?.Invoke(user);
    return user;
  }

  public async Task<AuthUser> CreateAsync(
      string password,
      Action<AuthUser>? configure = null
  )
  {
    var user = Build(configure);

    var result = await _userManager.CreateAsync(user, password);

    if (!result.Succeeded)
    {
      var errors = string.Join(", ", result.Errors.Select(e => e.Description));

      throw new InvalidOperationException($"Failed to create user: {errors}");
    }

    return user;
  }
}

