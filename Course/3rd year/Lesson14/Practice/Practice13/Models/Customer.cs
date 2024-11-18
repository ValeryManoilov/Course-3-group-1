using System.ComponentModel.DataAnnotations;

namespace Practice13.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Пока не добавлена автоинкрементация, добавляйте id сами")]
        public long Id { get; set; }

        [MinLength(5)]
        [Required(ErrorMessage = "Имя обязательно к заполнению!")]
        public string CustomerName { get; set; }

        [MinLength(5)]
        [Required(ErrorMessage = "Почта обязательна к обязательно к заполнению!")]
        public string CustomerEmail { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
