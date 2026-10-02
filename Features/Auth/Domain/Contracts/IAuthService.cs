namespace AspNetTestAppMVC.Features.Auth.Domain.Contracts;

using AspNetTestAppMVC.Features.Auth.DTO;

interface IAuthService {

  public AuthenticateOutput AuthenticateAsync(AuthenticateInput input);
}
