using JadooTravel.Dtos.ServiceDtos;
using JadooTravel.Dtos.TestimonialDtos;
using JadooTravel.Services.ServiceService;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers;

public class ServiceController : Controller
{
    private readonly IServiceService _service;

    public ServiceController(IServiceService service)
    {
        _service = service;
    }

    public async Task<IActionResult> ServiceList()
    {
        var values = await _service.GetAllServiceAsync();
        return View(values);
    }

    public IActionResult CreateService() => View();

    [HttpPost]
    public async Task<IActionResult> CreateService(CreateServiceDto model)
    {
        await _service.CreateServiceAsync(model);
        return RedirectToAction("ServiceList");
    }

    public async Task<IActionResult> UpdateService(string id)
    {
        var findId = await _service.GetServiceByIdAsync(id);
        var mapEntity = new UpdateServiceDto
        {
            Id = findId.Id,
            Description = findId.Description,
            IconUrl = findId.IconUrl,
            Title = findId.Title,
        };
        return View(mapEntity);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateService(UpdateServiceDto model)
    {
        await _service.UpdateServiceAsync(model);
        return RedirectToAction("ServiceList");
    }

    public async Task<IActionResult> DeleteService(string id)
    {
        await _service.DeleteServiceAsync(id);
        return RedirectToAction("ServiceList");
    }

}
