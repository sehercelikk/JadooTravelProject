using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers;

public class AdminUIController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
