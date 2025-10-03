using JadooTravel.Services.TranslatorService;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.ViewComponents;

public class _DefaultCategoryComponentPartial : ViewComponent
{
    private readonly TranslatorService _translator;

    public _DefaultCategoryComponentPartial(TranslatorService translator)
    {
        _translator = translator;
    }

    public IViewComponentResult Invoke()
    {
        return View();
    }
}
