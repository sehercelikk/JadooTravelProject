using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers;

public class TripPlanController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
