using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetTestAppMVC.Models;

namespace AspNetTestAppMVC.Controllers;

public class HomeController : Controller
{
  public IActionResult Index()
  {
    return View();
  }

  [HttpGet]
  public IActionResult FormsInteraction()
  {
    return View(new FormsInteractionViewModel());
  }

  [HttpPost]
  public IActionResult FormsInteraction(FormsInteractionViewModel model)
  {
    if (!ModelState.IsValid)
      return View(model);

    return View(model); // FullName is already up-to-date
  }

  public IActionResult Privacy()
  {
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
