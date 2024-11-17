namespace Practice13.Services.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public ProductType ProductCategory { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
