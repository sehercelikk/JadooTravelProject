﻿namespace JadooTravel.Dtos.CategoryDtos;

public class GetCategoryByIdDto
{
    public string Id { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }
    public bool Status { get; set; }
}
