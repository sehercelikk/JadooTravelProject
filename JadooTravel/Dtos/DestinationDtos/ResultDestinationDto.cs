﻿namespace JadooTravel.Dtos.DestinationDtos;

public class ResultDestinationDto
{
    public string Id { get; set; }
    public string CityCountry { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public string DayNight { get; set; }
    public int Capacity { get; set; }
    public string Description { get; set; }
}
