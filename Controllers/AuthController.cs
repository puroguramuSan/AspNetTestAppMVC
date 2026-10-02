using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetTestAppMVC.Models;

namespace AspNetTestAppMVC.Controllers;

public class AuthController : Controller
{
  public IActionResult Index()
  {
    return View(new LoginViewModel());
  }

  [HttpGet]
  public IActionResult Index(string? returnUrl = null)
  {
    return View(new LoginViewModel());
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Index(LoginViewModel model)
  {
    Console.WriteLine("Handling post" + ModelState.IsValid);
    if (!ModelState.IsValid) {
      return View(model);
    }

    if (model.Email == "test@email.com" && model.Password == "TestPass") {
      //return RedirectToAction("Index", "Home");
      model.ComponentState = ComponentStateEnum.Success;
      model.Error = $"Logeado con el usuario {model.Email}";
      return View(model);
    }

    model.ComponentState = ComponentStateEnum.Failure;
    model.Error = "Credenciales incorrectas";
    return View(model);
  }
}
