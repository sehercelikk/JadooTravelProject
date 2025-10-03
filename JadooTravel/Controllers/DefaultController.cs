using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            // Mevcut dili ViewBag’e ekle
            ViewBag.CurrentLanguage = GetCurrentLanguage();
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

        private string GetCurrentLanguage()
        {
            var langCookie = Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
            return langCookie != null ? langCookie.Split('|')[0].Split('=')[1] : "tr";
        }
    }
}
