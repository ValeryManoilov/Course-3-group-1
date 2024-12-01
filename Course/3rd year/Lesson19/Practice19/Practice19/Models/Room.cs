using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Practice19.Models
{
    public class Room
    {
        public int Id {  get; set; }
        public string HomeType  { get; set; }
        public string Address { get; set; }
        public int HasTv { get; set; }
        public int HasInternet { get; set; }
        public int HasKitchen { get; set; }
        public int HasAirCon { get; set; }
        public string EndDate {  get; set; }
        public int Price { get; set; }
        public int Latitude { get; set; }
        public int OwnerId { get; set; }
        public int Longitude { get; set; }

        public Room(int id, string hometype, string address, int hasTv, int hasInterner, int hasKitchen, int hasAirCon, string endDate, int price, int latitude, int longitude, int ownerId)
        {
            Id = id;
            HomeType = hometype;
            Address = address;
            HasTv = hasTv;
            HasInternet = hasInterner;
            HasKitchen = hasKitchen;
            HasAirCon = hasAirCon;
            EndDate = endDate;
            Price = price;
            Latitude = latitude;
            Longitude = longitude;
            OwnerId = ownerId;
        }
    }
}
