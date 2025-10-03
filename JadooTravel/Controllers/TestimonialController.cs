using JadooTravel.Dtos.CategoryDtos;
using JadooTravel.Dtos.TestimonialDtos;
using JadooTravel.Services.TestimonialService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.Controllers;

public class TestimonialController : Controller
{
    private readonly ITestimonialService _testimonialService;

    public TestimonialController(ITestimonialService testimonialService)
    {
        _testimonialService = testimonialService;
    }

    public async Task<IActionResult> TestimonialList()
    {
        var values = await _testimonialService.GetAllTestimonialAsync();
        return View(values);
    }

    public IActionResult CreateTestimonial() => View();

    [HttpPost]
    public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto model)
    {
        await _testimonialService.CreateTestimonialAsync(model);
        return RedirectToAction("TestimonialList");
    }

    public async Task<IActionResult> UpdateTestimonial(string id)
    {
        var findId =await _testimonialService.GetTestimonialByIdAsync(id);
        var mapEntity = new UpdateTestimonialDto
        {
            CityCountry = findId.CityCountry,
            Description = findId.Description,
            FullName = findId.FullName,
            Id = findId.Id,
            ImageUrl = findId.ImageUrl
        };
        return View(mapEntity);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto model)
    {
        await _testimonialService.UpdateTestimonialAsync(model);
        return RedirectToAction("TestimonialList");
    }

    public async Task<IActionResult> DeleteTestimonial(string id)
    {
        await _testimonialService.DeleteTestimonialAsync(id);
        return RedirectToAction("TestimonialList");
    }

}
