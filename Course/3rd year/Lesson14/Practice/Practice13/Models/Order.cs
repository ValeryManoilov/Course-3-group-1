using System.ComponentModel.DataAnnotations;

namespace Practice13.Models
{
    public class Order
    {
        [Required(ErrorMessage = "Пока не добавлена автоинкрементация, добавляйте id сами")]
        public long Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Вы должны заказать минимум 1 продукт!")]
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        public Customer OrderCustomer { get; set; }

        [Required(ErrorMessage = "Вам необходимо прикрепить заказ к покупателю")]
        public long CustomerId { get; set; }
    }
}
