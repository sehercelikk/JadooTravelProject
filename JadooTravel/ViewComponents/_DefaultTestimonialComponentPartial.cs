using JadooTravel.Services.TestimonialService;
using JadooTravel.Services.TranslatorService;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.ViewComponents;

public class _DefaultTestimonialComponentPartial : ViewComponent
{
    private readonly ITestimonialService _testimonialService;
    private readonly TranslatorService _translator;

    public _DefaultTestimonialComponentPartial(ITestimonialService testimonialService, TranslatorService translator)
    {
        _testimonialService = testimonialService;
        _translator = translator;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _testimonialService.GetAllTestimonialAsync();
        string header = "İnsanlar Bizim Hakkımızda Ne Diyor";
        string subHeader = "REFERANSLAR";



        var lang = HttpContext.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName]?.Split('|')[0].Split('=')[1] ?? "tr";

        if (lang != "tr")
        {
            foreach (var t in values)
            {
                t.Description = await _translator.TranslateAsync(t.Description, lang);
                t.CityCountry = await _translator.TranslateAsync(t.CityCountry, lang);
                header = await _translator.TranslateAsync(header, lang);
                subHeader = await _translator.TranslateAsync(subHeader, lang);
            }
        }
        ViewBag.TestimonialHeader = header;
        ViewBag.TestimonialSubHeader = subHeader;
        return View(values);
    }
}
