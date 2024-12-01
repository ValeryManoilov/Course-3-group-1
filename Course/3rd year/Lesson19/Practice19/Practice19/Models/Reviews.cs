using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice19.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public int ReservationId { get; set; }

        public Reviews() { }

        public Reviews(int id, int rating, int reservationId)
        {
            Id = id;
            Rating = rating;
            ReservationId = reservationId;
        }
    }
}
