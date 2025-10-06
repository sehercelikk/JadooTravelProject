using JadooTravel.Services.FeatureService;
using JadooTravel.Services.TranslatorService;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.ViewComponents;

public class _DefaultFeatureComponentPartial: ViewComponent
{
    private readonly IFeatureService _featureService;
    private readonly TranslatorService _translatorService;
    public _DefaultFeatureComponentPartial(IFeatureService featureService, TranslatorService translatorService)
    {
        _featureService = featureService;
        _translatorService = translatorService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _featureService.GetAllFeaturesAsync();
        var play = "İzle";
        var lang = HttpContext.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName]?.Split('|')[0].Split('=')[1] ?? "tr";

        if (lang != "tr")
        {
            foreach (var t in result)
            {
                t.Title = await _translatorService.TranslateAsync(t.Title, lang);
                t.MainTitle = await _translatorService.TranslateAsync(t.MainTitle, lang);
                t.Description = await _translatorService.TranslateAsync(t.Description, lang);
                play = await _translatorService.TranslateAsync(play, lang);

            }
        }
        ViewBag.Play = play;
        return View(result);
    }
}
