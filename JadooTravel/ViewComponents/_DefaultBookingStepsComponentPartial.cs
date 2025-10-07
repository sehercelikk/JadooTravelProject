using JadooTravel.Services.ReservationService;
using JadooTravel.Services.TranslatorService;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.ViewComponents;

public class _DefaultBookingStepsComponentPartial: ViewComponent
{
    private readonly IRezervationService _rezervationService;
    private readonly TranslatorService _translatorService;

    public _DefaultBookingStepsComponentPartial(IRezervationService rezervationService, TranslatorService translatorService)
    {
        _rezervationService = rezervationService;
        _translatorService = translatorService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result=await _rezervationService.GetAllRezervationAsync();
        var title = "3 Adımda Rezervasyonunuzu Yap";
        var subtitle = "Kolay ve Hızlı Rezervasyon";
        var adiniz = "Adınız";
        var eposta = "E-Posta";
        var mesaj = "Mesajınız";
        var gonder = "Rezervasyon Talebi Oluştur";
        var baslik = "Rezervasyon için Bize Yazın";

        var lang = HttpContext.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName]?.Split('|')[0].Split('=')[1] ?? "tr";

        if (lang != "tr")
        {
            foreach (var t in result)
            {
                t.Title = await _translatorService.TranslateAsync(t.Title, lang);
                t.Description = await _translatorService.TranslateAsync(t.Description, lang);
                title = await _translatorService.TranslateAsync(title, lang);
                subtitle = await _translatorService.TranslateAsync(subtitle, lang);
                adiniz = await _translatorService.TranslateAsync(adiniz, lang);
                eposta = await _translatorService.TranslateAsync(eposta, lang);
                mesaj = await _translatorService.TranslateAsync(mesaj, lang);
                gonder = await _translatorService.TranslateAsync(gonder, lang);
                baslik = await _translatorService.TranslateAsync(baslik, lang);
            }
        }
        ViewBag.Title= title;
        ViewBag.Subtitle= subtitle;
        ViewBag.Adiniz = adiniz;
        ViewBag.EPosta = eposta;
        ViewBag.Mesaj= mesaj;
        ViewBag.Gönder = gonder;
        ViewBag.Baslik= baslik;

        return View(result);
    }
}
