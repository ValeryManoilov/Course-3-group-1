namespace Practice13.Services.Models
{
    public class Order
    {
        public long Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
        public Customer OrderCustomer { get; set; }
        public long CustomerId { get; set; }
    }
}
