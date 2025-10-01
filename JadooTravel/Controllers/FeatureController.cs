using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers;

public class FeatureController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
