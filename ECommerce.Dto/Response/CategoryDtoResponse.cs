﻿namespace ECommerce.Dto.Response;

public class CategoryDtoResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}