namespace AspNetTestAppMVC.Features.Auth.DTO;

class AuthenticateOutput {

  public string? Email { get; set; }
  public string? Password { get; set; }

  public static AuthenticateOutput Create(string email, string password) => new() {
    Email = email,
    Password = password
  };
}
