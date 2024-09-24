﻿namespace MyPractice;

public class ProductsSales
{
    public DateTime Date {get; set;}
    public string Product {get; set;}
    public string Region {get; set;}
    public int Quantity {get; set;}
    public decimal Price {get; set;}
    public ProductsSales() { }
    public ProductsSales(DateTime date, string product, string region, int quantity, decimal price)
    {
        Date = date;
        Product = product;
        Region = region;
        Quantity = quantity;
        Price = price;
    }
}