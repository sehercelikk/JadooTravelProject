using JadooTravel.Dtos.FeatureDtos;
using JadooTravel.Services.FeatureService;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers;

public class FeatureController : Controller
{
    private readonly IFeatureService _featureService;

    public FeatureController(IFeatureService featureService)
    {
        _featureService = featureService;
    }

    public async Task<IActionResult> FeatureList()
    {
        var result = await _featureService.GetAllFeaturesAsync();
        return View(result);
    }

    public IActionResult CreateFeature() => View();

    [HttpPost]
    public async Task<IActionResult> CreateFeature(CreateFeatureDto model)
    {
        var result = await _featureService.CreateFeatureAsync(model);
        if (result)
            return RedirectToAction("FeatureList");
        else
        {
            ViewBag.message = "Zaten kayıt mevcut, eklenmedi.";
            return View();
        }
    }

    public async Task<IActionResult> UpdateFeature(string id)
    {
        var findId = await _featureService.GetFeatureByIdAsync(id);
        var mapEntity = new UpdateFeatureDto
        {
            Id = findId.Id,
            Description = findId.Description,
            MainTitle = findId.MainTitle,
            Title = findId.Title,
            VideoUrl = findId.VideoUrl,
        };
        return View(mapEntity);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureDto model)
    {
        await _featureService.UpdateFeatureAsync(model);
        return RedirectToAction("FeatureList");
    }

    public async Task<IActionResult> DeleteCategory(string id)
    {
        await _featureService.DeleteFeatureAsync(id);
        return RedirectToAction("FeatureList");
    }

}
