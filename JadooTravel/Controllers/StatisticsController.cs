using JadooTravel.Services.DestinationServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.Controllers;

public class StatisticsController : Controller
{
    private readonly IDestinationService _destinationService;

    public StatisticsController(IDestinationService destinationService)
    {
        _destinationService = destinationService;
    }


    [HttpGet]
    public async Task<IActionResult> StatisticList()
    {
        var values = await _destinationService.TourWidthCapasity();
        return View(values);
    }
}
