using JadooTravel.Services.TranslatorService;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.ViewComponents;

public class _DefaultNavbarComponentPartial : ViewComponent
{
    private readonly TranslatorService _translator;

    public _DefaultNavbarComponentPartial(TranslatorService translator)
    {
        _translator = translator;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {

        var lang = HttpContext.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName]?.Split('|')[0].Split('=')[1] ?? "tr";
        var hizmet = "Hizmetler";
        var turlar = "Turlar";
        var rezervasyon = "Rezervasyonlar";
        var referans = "Referanslar";
        var iletisim = "İletişim";
        if (lang != "tr")
        {
            // async çeviri servisi ile çevir
            hizmet = await _translator.TranslateAsync(hizmet, lang);
            turlar = await _translator.TranslateAsync(turlar, lang);
            rezervasyon = await _translator.TranslateAsync(rezervasyon, lang);
            referans = await _translator.TranslateAsync(referans, lang);
            iletisim = await _translator.TranslateAsync(iletisim, lang);
        }
        ViewBag.Hizmet = hizmet;
        ViewBag.Turlar = turlar;
        ViewBag.Rezervasyon = rezervasyon;
        ViewBag.Referans = referans;
        ViewBag.Iletisim = iletisim;

        return View();
    }
}
