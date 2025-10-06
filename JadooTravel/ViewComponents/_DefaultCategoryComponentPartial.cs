using JadooTravel.Services.CategoryServices;
using JadooTravel.Services.DestinationServices;
using JadooTravel.Services.TranslatorService;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.ViewComponents;

public class _DefaultCategoryComponentPartial : ViewComponent
{
    private readonly TranslatorService _translator;
    private readonly ICategoryService _categoryService;

    public _DefaultCategoryComponentPartial(TranslatorService translator, ICategoryService categoryService)
    {
        _translator = translator;
        _categoryService = categoryService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _categoryService.GetAllCategoriesAsync();
        var message = "En İyi Hizmetleri Sunuyoruz.";
        var lang = HttpContext.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName]?.Split('|')[0].Split('=')[1] ?? "tr";

        if (lang != "tr")
        {
            foreach (var t in values)
            {
                t.CategoryName = await _translator.TranslateAsync(t.CategoryName, lang);
                t.Description = await _translator.TranslateAsync(t.Description, lang);
                message = await _translator.TranslateAsync(message, lang);
            }
        }
        ViewBag.Message = message;
        return View(values);
    }
}
