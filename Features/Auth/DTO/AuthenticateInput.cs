namespace AspNetTestAppMVC.Features.Auth.DTO;

class AuthenticateInput {

  public bool Success { get; init; }

  public string? AccessToken { get; set; }
  public string? RefreshToken { get; set; }
  public DateTime? AccessTokenExpiresAt { get; init; }
  public DateTime? RefreshTokenExpiresAt { get; init; }

  public string? ErrorMessage { get; set; }
  public static AuthenticateInput AuthSuccess(
      string accessToken,
      string refreshToken,
      DateTime accessTokenExpiresAt,
      DateTime refreshTokenExpiresAt
  ) => new() {
    Success = true,

    AccessToken = accessToken,
    RefreshToken = refreshToken,
    AccessTokenExpiresAt = accessTokenExpiresAt,
    RefreshTokenExpiresAt = refreshTokenExpiresAt
  };

  public static AuthenticateInput AuthFailure(
    string message
  ) => new() {
    Success = false,
    ErrorMessage = message
  };
}
