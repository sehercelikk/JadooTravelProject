using JadooTravel.Services.TestimonialService;
using Microsoft.AspNetCore.Mvc;

namespace JadooTravel.ViewComponents;

public class _DefaultTestimonialComponentPartial : ViewComponent
{
    private readonly ITestimonialService _testimonialService;

    public _DefaultTestimonialComponentPartial(ITestimonialService testimonialService)
    {
        _testimonialService = testimonialService;
    }

    public IViewComponentResult Invoke()
    {
        return View();
    }
}
