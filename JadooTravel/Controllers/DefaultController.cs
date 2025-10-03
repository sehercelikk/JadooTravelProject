using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers;

public class DefaultController : Controller
{
    public IActionResult Index()
    {
        ViewBag.CurrentLanguage = Request.Cookies[CookieRequestCultureProvider.DefaultCookieName]?.Split('|').FirstOrDefault()?.Split('=')[1] ?? "tr";
        return View();
    }

    [HttpGet]
    public IActionResult SetLanguage(string culture, string returnUrl)
    {
        if (!string.IsNullOrEmpty(culture))
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
        }

        return LocalRedirect(returnUrl ?? "/");
    }
}
