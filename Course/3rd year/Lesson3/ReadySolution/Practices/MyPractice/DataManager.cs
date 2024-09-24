using System;
using System.Collections.Generic;
using System.Linq;

namespace MyPractice;
public class DataManager
{
    private List<ProductsSales> _products;

    public DataManager(List<ProductsSales> products)
    {
        _products = products;
    }

    // Часть Б
    // Добавление продукта
    public void AddProduct(ProductsSales product)
    {
        if (product == null)
        {
            throw new Exception("Продукт введен некорректно");
        }
        _products.Add(product);
    }

    // Чтение списка
    public IEnumerable<ProductsSales> GetProducts()
    {
        foreach(var item in _products)
        {
            Console.WriteLine($"{item.Date} {item.Product} {item.Region} {item.Quantity} {item.Price}");
        }
        return _products;
    }

    // Удаление продукта
    public void DeleteProduct(ProductsSales product)
    {
        _products.Remove(product);
    }

    // Часть С

    private IEnumerable<ProductsSales> GetNeedListByProductName(string ProductName)
    {
        if (ProductName == "all")
        {
            return _products;
        }
        else
        {
            return _products.Where(product => product.Product == ProductName);
        }
    }

    public void PrintList(IEnumerable<ProductsSales> ProductList)
    {
        foreach(var product in ProductList)
        {
            Console.WriteLine($"{product.Date} {product.Product} {product.Region} {product.Quantity} {product.Price}");
        }
    }
    // Сумма всех продаж по продукту
    public double GetSumOfSales(string ProductName)
    {
        double sum = 0;
        IEnumerable<ProductsSales> NeedProducts = GetNeedListByProductName(ProductName);
        foreach(var product in NeedProducts)
        {
            sum = sum + product.Quantity * Convert.ToDouble(product.Price);
        }
        return sum;
    }
    // Средние продажи по рподукту
    public double GetMiddleCountOfSales(string ProductName)
    {
        double sum = 0;
        int count = 0;
        IEnumerable<ProductsSales> NeedProducts = GetNeedListByProductName(ProductName);
        foreach(var product in NeedProducts)
        {
            sum = sum + product.Quantity;
            count++;
        }
        return sum/count;
    }
    // Сумма продаж по продукту за период
    public double GetSumOfSalesOnThePeriod(string ProductName, DateTime FirstDate, DateTime LastDate)
    {
        double sum = 0;
        IEnumerable<ProductsSales> NeedProducts = GetNeedListByProductName(ProductName).Where(product => (DateTime.Compare(product.Date, FirstDate) > 0 && DateTime.Compare(product.Date, LastDate) < 0));
        foreach(var product in NeedProducts)
        {
            sum = sum + product.Quantity;
        }
        return sum;
    }

    // Фильтрация по дате
    public IEnumerable<ProductsSales> FilterProductsByDate(DateTime FirstDate, DateTime LastDate)
    {
        return _products.Where(product => (DateTime.Compare(product.Date, FirstDate) > 0 && DateTime.Compare(product.Date, LastDate) < 0));
    }
    // Фильтрация по цене
    public IEnumerable<ProductsSales> FilterProductsByPrice(decimal FirstPrice, decimal LastPrice)
    {
        return _products.Where(product => (Convert.ToInt32(FirstPrice) < Convert.ToInt32(product.Price) && Convert.ToInt32(product.Price) < Convert.ToInt32(LastPrice)));
    }
}