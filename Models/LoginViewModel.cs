using System.ComponentModel.DataAnnotations;

namespace AspNetTestAppMVC.Models;

public enum ComponentStateEnum {
  Success,
  Info,
  Failure
}

public class LoginViewModel
{

  private const string RequiredMessage = "Este campo es obligatorio";

  [Required(ErrorMessage = RequiredMessage)]
  [EmailAddress(ErrorMessage = "El correo no tienen un formato válido")]
  [Display(Name = "Correo")]
  public string Email { get; set; } = string.Empty;

  [Required(ErrorMessage = RequiredMessage)]
  [DataType(DataType.Password)]
  [Display(Name = "Contraseña")]
  public string Password { get; set; } = string.Empty;

  public string Error { get; set; } = string.Empty;
  public ComponentStateEnum ComponentState { get; set; } = ComponentStateEnum.Info;
}
