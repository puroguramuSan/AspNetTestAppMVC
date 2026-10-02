namespace AspNetTestAppMVC.Features.Auth.Infrastructure.Services;

using AspNetTestAppMVC.Features.Auth.Domain.Contracts;
using AspNetTestAppMVC.Features.Auth.DTO;

class AuthService : IAuthService {

  public AuthenticateOutput AuthenticateAsync(AuthenticateInput input) {
    AuthenticateOutput output = new();

    return output;
  }
}
