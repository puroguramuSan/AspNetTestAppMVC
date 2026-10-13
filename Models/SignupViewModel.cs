using System.ComponentModel.DataAnnotations;

namespace AspNetTestAppMVC.Models;

public enum SignupComponentState {
  Success,
  Info,
  Failure,
  Default
}

public class SignupViewModel
{
  private const string RequiredMessage = "Este campo es obligatorio";

  [Required(ErrorMessage = RequiredMessage)]
  [EmailAddress(ErrorMessage = "El correo no tiene un formato válido")]
  [Display(Name = "Correo")]
  public string Email { get; set; } = string.Empty;

  [Required(ErrorMessage = RequiredMessage)]
  [RegularExpression(
    @"/^[a-zA-Z0-9\_\-\@]{1,25}$/",
    ErrorMessage = "El nombre de ususario solo contener letra, números y @ - _"
  )]
  public string Username { get; set; } = string.Empty;

  [Required(ErrorMessage = RequiredMessage)]
  [RegularExpression(
    @"/^[a-zA-Z]$/"
  )]

  public string Error { get; set; } = string.Empty;
  public SignupComponentState ComponentState { get; set; } = SignupComponentState.Default
}
