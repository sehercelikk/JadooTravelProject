using JadooTravel.Dtos.CategoryDtos;
using JadooTravel.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _catgoryService;

    public CategoryController(ICategoryService catgoryService)
    {
        _catgoryService = catgoryService;
    }

    public async Task<IActionResult> CategoryList()
    {
        var catgory=await _catgoryService.GetAllCategoriesAsync();
        return View(catgory);
    }

    public IActionResult CreateCatgory() => View();

    [HttpPost]
    public async Task<IActionResult> CreateCatgory(CreateCategoryDto model)
    {
        await _catgoryService.CreateCategoryAsync(model);
        return RedirectToAction("CategoryList");
    }

    public async Task<IActionResult> UpdateCategory(string id)
    {
        var findId = await _catgoryService.GetCategoryByIdAsync(id);
        return View(findId);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto model)
    {
        await _catgoryService.UpdateCategoryAsync(model);
        return RedirectToAction("CategoryList");
    }

    public async Task<IActionResult> DeleteCategory(string id)
    {
        await _catgoryService.DeleteCategoryAsync(id);
        return RedirectToAction("CategoryList");
    }

    [HttpGet]
    public async Task<IActionResult> GetByIdCategory(string id)
    {
        var value = await _catgoryService.GetCategoryByIdAsync(id);
        return View(value);
    }
}
