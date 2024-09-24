using System.Linq;

namespace MyPractice;
class Program
{
    static void Main(string[] args)
    {
        string FILEPATH = "sales.csv";

        // Тесты

        // 1) Чтение списка

        var ProductsData = MyCsvDataWorker.CsvRead(FILEPATH);
        var MyManager = new DataManager(ProductsData.ToList());
        
        // MyManager.PrintList(MyManager.GetProducts());

        // 2) Добавление 5 элементов и запись

        ProductsSales TestProduct1 = new ProductsSales
        {Date = new DateTime(2024, 09, 24), 
        Product = "Videocard", 
        Region = "America", 
        Quantity = 11, 
        Price = 799.9M};

        ProductsSales TestProduct2 = new ProductsSales
        {Date = new DateTime(2023, 08, 03), 
        Product = "Smartphone", 
        Region = "Europe", 
        Quantity = 89, 
        Price = 610.0M};

        ProductsSales TestProduct3 = new ProductsSales
        {Date = new DateTime(2023, 01, 09), 
        Product = "Mouse", 
        Region = "America", 
        Quantity = 53, 
        Price = 59.0M};

        ProductsSales TestProduct4 = new ProductsSales
        {Date = new DateTime(2024, 07, 01), 
        Product = "Console", 
        Region = "Asia", 
        Quantity = 122, 
        Price = 199.0M};

        ProductsSales TestProduct5 = new ProductsSales
        {Date = new DateTime(2022, 12, 02), 
        Product = "Keyboard", 
        Region = "Europe", 
        Quantity = 67, 
        Price = 79.0M};

        MyManager.AddProduct(TestProduct1);
        MyManager.AddProduct(TestProduct2);
        MyManager.AddProduct(TestProduct3);
        MyManager.AddProduct(TestProduct4);
        MyManager.AddProduct(TestProduct5);

        MyCsvDataWorker.CsvWrite(FILEPATH, MyManager.GetProducts());

        // MyManager.PrintList(MyManager.GetProducts());

        // 3) Удаление элементов

        MyManager.DeleteProduct(TestProduct1);
        MyManager.DeleteProduct(TestProduct2);
        MyManager.DeleteProduct(TestProduct3);
        MyManager.DeleteProduct(TestProduct4);
        MyManager.DeleteProduct(TestProduct5);

        MyCsvDataWorker.CsvWrite(FILEPATH, MyManager.GetProducts());

        // MyManager.PrintList(MyManager.GetProducts());

        // 4) Проверка фильтраций

        // MyManager.PrintList(MyManager.FilterProductsByDate(new DateTime(2023, 06, 01), new DateTime(2023, 09, 01)))

        // MyManager.PrintList(MyManager.FilterProductsByDate(decimal 50.0M, decimal(100.0M))

        // 5) Проверка функций-агрегаций

        // MyManager.PrintList(MyManager.GetSumOfSales("Smartphone"));

        // MyManager.PrintList(MyManager.GetMiddleCountOfSales("all"));

        // MyManager.PrintList(MyManager.GetSumOfSalesOnThePeriod("Camera", new DateTime(2023, 03, 01), new DateTime(2023, 06, 01)));

    }
}