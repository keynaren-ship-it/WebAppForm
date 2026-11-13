using Microsoft.AspNetCore.Mvc;
using WebAppForm.Models;

namespace WebAppForm.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) => _logger = logger;

    [HttpGet]
    public IActionResult Index() => View(new PersonDetails());

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult Index(PersonDetails model)
    {
        if (!ModelState.IsValid) return View(model);

        // Structured log entry (visible in console, Azure Log Stream / App Service logs)
        _logger.LogInformation(
            "Form submitted: FirstName={FirstName}, LastName={LastName}, DOB={DOB:yyyy-MM-dd}, Location={Location}",
            model.FirstName, model.LastName, model.DOB, model.Location);

        return RedirectToAction(nameof(Thanks));
    }

    public IActionResult Thanks() => View();

    [ResponseCache(NoStore = true)]
    public IActionResult Error() => Content("An error occurred.");
}
