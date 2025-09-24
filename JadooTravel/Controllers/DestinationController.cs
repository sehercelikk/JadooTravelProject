using JadooTravel.Dtos.DestinationDtos;
using JadooTravel.Services.DestinationServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.Controllers;

public class DestinationController : Controller
{
    private readonly IDestinationService _destinationService;

    public DestinationController(IDestinationService destinationService)
    {
        _destinationService = destinationService;
    }

    public async Task<IActionResult> DestinationList()
    {
        var values= await _destinationService.GetDestinationListAsync();
        return View(values);
    }

    public IActionResult CreateDestination() => View();

    [HttpPost]
    public async Task<IActionResult> CreateDestination(CreateDestinationDto model)
    {
        await _destinationService.CreateDestinationAsync(model);
        return RedirectToAction("DestinationList");
    }

    public async Task<IActionResult> DeleteDestination(string id)
    {
        await _destinationService.DeleteDestinationAsync(id);
        return RedirectToAction("DestinationList");
    }

    public async Task<IActionResult> UpdateDestination(string id)
    {
        var findId = await _destinationService.GetDestinationByIdAsync(id);
        return View(findId);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateDestination(UpdateDestinationDto model)
    {
        await _destinationService.UpdateDestinationAsync(model);
        return RedirectToAction("DestinationList");

    }
}
