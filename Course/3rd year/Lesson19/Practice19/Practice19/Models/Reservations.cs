using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice19.Models
{
    public class Reservations
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }

        public Reservations() { }

        public Reservations(int id, int userId, int roomId, string startDate, string endDate, int price, int total)
        {
            Id = id;
            UserId = userId;
            RoomId = roomId;
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
            Total = total;
        }
    }
}
