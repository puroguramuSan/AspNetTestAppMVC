using Microsoft.AspNetCore.Identity;

namespace AspNetTestAppMVC.Features.Auth.Infrastructure.Database.Models;

public class AuthUser : IdentityUser {

  public DateTime? DeletedAt { get; set; }
  public DateTime? LastLoginAt { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
