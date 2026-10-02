namespace AspNetTestAppMVC.Features.Auth.Infrastructure.Services;

using Microsoft.AspNetCore.Identity;
using AspNetTestAppMVC.Features.Auth.Domain.Contracts;
using AspNetTestAppMVC.Features.Auth.Infrastructure.Database.Models;

class EncryptionService(IPasswordHasher<AuthUser> hasher) : IEncryptionService<AuthUser>
{
    public string Hash(string password, AuthUser user)
        => hasher.HashPassword(user, password);

    public PasswordVerificationResult VerifyPassword(string providedPassword, string hashedPassword, AuthUser user) {
      return hasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
    }
}
