using System.ComponentModel.DataAnnotations;

namespace AspNetTestAppMVC.Models;

public enum StringTreatment
{
  UpperCase,
  LowerCase,
  CamelCase
}

public class FormsInteractionViewModel
{
  private const string RequiredMessage = "Este campo es obligatorio";

  [Required(ErrorMessage = RequiredMessage)]
  [Display(Name = "Tratamiento")]
  public StringTreatment? Treatment { get; set; }

  [Required(ErrorMessage = RequiredMessage)]
  [DataType(DataType.Text)]
  [Display(Name = "Nombre")]
  public string Name { get; set; } = string.Empty;

  [DataType(DataType.Text)]
  [Display(Name = "Apellido paterno")]
  public string PaternalSurname { get; set; } = string.Empty;

  [DataType(DataType.Text)]
  [Display(Name = "Apellido materno")]
  public string MaternalSurname { get; set; } = string.Empty;

  [Display(Name = "Apellido primero")]
  public bool PaternalFirst { get; set; } = false;

  public string Error { get; set; } = string.Empty;
  public string[] BaseName =>
    PaternalFirst
        ? [PaternalSurname, Name, MaternalSurname]
        : [Name, PaternalSurname, MaternalSurname];
  public Dictionary<StringTreatment, Func<string, string>> Treatments { get; } = new()
  {
    [StringTreatment.CamelCase] = ToCamelTreatment,
    [StringTreatment.LowerCase] = ToLowerTreatment,
    [StringTreatment.UpperCase] = ToUpperTreatment
  };

  public string FullName =>
    Treatment is not null && Treatments.TryGetValue(Treatment.Value, out var t)
        ? ComposeString(BaseName, t)
        : string.Join(" ", BaseName);
  private string ComposeString(string[] baseName, Func<string, string> Treatment)
  {
    return baseName.Aggregate(string.Empty, (acc, c) =>
    {
      return string.IsNullOrEmpty(c) ? acc : acc + Treatment(c).Trim() + " ";
    });
  }

  private static string ToLowerTreatment(string input)
  {
    return input.ToLowerInvariant();
  }

  private static string ToUpperTreatment(string input)
  {
    return input.ToUpperInvariant();
  }

  private static string ToCamelTreatment(string input)
  {
    if (string.IsNullOrEmpty(input))
    {
      return input;
    }

    return char.ToUpperInvariant(input[0]) + input[1..];
  }
}
