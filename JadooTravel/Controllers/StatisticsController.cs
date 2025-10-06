using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult StatisticList()
        {
            return View();
        }
    }
}
