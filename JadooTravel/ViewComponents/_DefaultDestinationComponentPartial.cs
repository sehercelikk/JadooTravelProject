using JadooTravel.Entities;
using JadooTravel.Services.DestinationServices;
using JadooTravel.Services.TranslatorService;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.ViewComponents;

public class _DefaultDestinationComponentPartial : ViewComponent
{
    private readonly IDestinationService _destinationService;
    private readonly TranslatorService _translatorService;
    public _DefaultDestinationComponentPartial(IDestinationService destinationService, TranslatorService translator)
    {
        _destinationService = destinationService;
        _translatorService = translator;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values= await _destinationService.GetDestinationListAsync();
        var title1 = "En Çok Tercih Edilen";
        var title2 = "Tur Rotalarınız";
        var lang = HttpContext.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName]?.Split('|')[0].Split('=')[1] ?? "tr";

        if (lang != "tr")
        {
            foreach (var t in values)
            {
                t.Description = await _translatorService.TranslateAsync(t.Description, lang);
                t.DayNight = await _translatorService.TranslateAsync(t.DayNight, lang);
                t.CityCountry = await _translatorService.TranslateAsync(t.CityCountry, lang);
                t.Price = decimal.Parse(await _translatorService.TranslateAsync(t.Price.ToString(), lang));
                t.Capacity =int.Parse(await _translatorService.TranslateAsync(t.Capacity.ToString(), lang));
                title1 = await _translatorService.TranslateAsync(title1, lang);
                title2 = await _translatorService.TranslateAsync(title2, lang);

            }
        }
        ViewBag.Title1 = title1;
        ViewBag.Title2 = title2;
        return View(values);
    }
}
