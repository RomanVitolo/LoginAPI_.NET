﻿namespace API.FurnitureStore.Shared;

public class Product
{
    public int Id { get; set; }
    public int Name { get; set; }
    public decimal Price { get; set; }
    public int ProductCategoryId { get; set; }
}