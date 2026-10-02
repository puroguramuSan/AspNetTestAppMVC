namespace AspNetTestAppMVC.Features.Auth.Domain.Contracts;

using Microsoft.AspNetCore.Identity;

interface IEncryptionService<TUser> {
  public string Hash(string password, TUser user);

  public PasswordVerificationResult VerifyPassword(string providedPassword, string hashedPassword, TUser user);
}
