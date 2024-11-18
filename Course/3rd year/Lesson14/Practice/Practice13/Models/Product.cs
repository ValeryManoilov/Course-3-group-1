using System.ComponentModel.DataAnnotations;

namespace Practice13.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Пока не добавлена автоинкрементация, добавляйте id сами")]
        public long Id { get; set; }

        [MinLength(5)]
        [Required(ErrorMessage = "Название обязательно к заполнению!")]
        public string ProductName { get; set; }

        [MinLength(20)]
        [Required(ErrorMessage = "Описание обязательно к заполнению!")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Категория обязательна к заполнению!")]
        public ProductType ProductCategory { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
