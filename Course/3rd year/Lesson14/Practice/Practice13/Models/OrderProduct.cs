namespace Practice13.Models
{
    public class OrderProduct
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
