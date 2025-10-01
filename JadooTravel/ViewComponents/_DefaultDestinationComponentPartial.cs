﻿using JadooTravel.Services.DestinationServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JadooTravel.ViewComponents;

public class _DefaultDestinationComponentPartial : ViewComponent
{
    private readonly IDestinationService _destinationService;

    public _DefaultDestinationComponentPartial(IDestinationService destinationService)
    {
        _destinationService = destinationService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values= await _destinationService.GetDestinationListAsync();
        return View(values);
    }
}
