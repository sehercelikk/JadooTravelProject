using JadooTravel.Dtos.FeatureDtos;
using JadooTravel.Dtos.ReservationDtos;
using JadooTravel.Services.ReservationService;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers;

public class ReservationController : Controller
{
    private readonly IRezervationService _rezervationService;

    public ReservationController(IRezervationService rezervationService)
    {
        _rezervationService = rezervationService;
    }

    public async Task<IActionResult> ReservationList()
    {
        var result = await _rezervationService.GetAllRezervationAsync();
        return View(result);
    }

    public IActionResult CreateReservation() => View();

    [HttpPost]
    public async Task<IActionResult> CreateReservation(CreateRezervationDto model)
    {
        await _rezervationService.CreateRezervationAsync(model);
        return RedirectToAction("ReservationList");
    }

    public async Task<IActionResult> UpdateReservation(string id)
    {
        var findId = await _rezervationService.GetRezervationByIdAsync(id);
        var mapEntity = new UpdateRezervationDto
        {
            Id = findId.Id,
            Description = findId.Description,
            Title = findId.Title,
            IconUrl = findId.IconUrl,
        };
        return View(mapEntity);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateReservation(UpdateRezervationDto model)
    {
        await _rezervationService.UpdateRezervationAsync(model);
        return RedirectToAction("ReservationList");
    }

    public async Task<IActionResult> DeleteReservation(string id)
    {
        await _rezervationService.DeleteRezervationAsync(id);
        return RedirectToAction("ReservationList");
    }
}
