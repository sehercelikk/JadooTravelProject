using JadooTravel.Dtos.TripPlanDtos;
using JadooTravel.Services.UserReservationService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.Controllers;

public class BookingController : Controller
{
    private readonly IUserReservationService _userReservationService;

    public BookingController(IUserReservationService userReservationService)
    {
        _userReservationService = userReservationService;
    }

    public async Task<IActionResult> UserReservationList()
    {
        var result= await _userReservationService.GetAllUserReservationAsync();
        return View(result);
    }


    [HttpPost]
    public async Task<IActionResult> CreateUserReservation(CreateUserReservationDto model)
    {
       await _userReservationService.CreateUserReservationAsync(model);
        return RedirectToAction("Index", "Default");
    }

    public async Task<IActionResult> DeleteUserReservation(string id)
    {
        await _userReservationService.DeleteUserReservationAsync(id);
        return RedirectToAction("UserReservationList");
    }
}
