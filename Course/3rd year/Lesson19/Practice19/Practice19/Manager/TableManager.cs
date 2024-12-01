using Practice19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Practice19.Tables;

namespace Practice19.Manager
{
    public class TableManager
    {
        private static string path = "Data Source=data.db";
        ReviewsTable reviews = new ReviewsTable(path);
        UsersTable users = new UsersTable(path);
        ReservationsTable reservations = new ReservationsTable(path);
        RoomsTable rooms = new RoomsTable(path);

        private void PrintAllRooms(List<Room> rooms)
        {
            Console.WriteLine("|Id|HomeType|Address|HasInternet|HasKitchen|HasAirCon|HasTv|EndDate|Price|Latitude|Longitude|OwnerId|");
            foreach (Room room in rooms)
            {
                Console.WriteLine($"|{room.Id}|{room.HomeType}|{room.Address}|{room.HasInternet}|{room.HasKitchen}|{room.HasAirCon}|{room.HasTv}|{room.EndDate}|{room.Price}|{room.Latitude}|{room.OwnerId}|{room.Longitude}|");
            }
        }

        private void PrintAllReservations(List<Reservations> reservations)
        {
            Console.WriteLine("|Id|UserId|RoomId|StartDate|EndDate|Price|Total|");
            foreach (Reservations reservation in reservations)
            {
                Console.WriteLine($"|{reservation.Id}|{reservation.UserId}|{reservation.RoomId}|{reservation.StartDate}|{reservation.EndDate}|{reservation.Price}|{reservation.Total}|");
            }
        }

        private void PrintAllUsers(List<User> users)
        {
            Console.WriteLine("|Id|Name|Email|IsEmailVerified|Password|Phone|");
            foreach (User user in users)
            {
                Console.WriteLine($"|{user.Id}|{user.Name}|{user.Email}|{user.IsEmailVerified}|{user.Password}|{user.Phone}|");
            }
        }

        private void PrintAllReviews(List<Reviews> reviews)
        {
            Console.WriteLine("|Id|Rating|ReservationId|");
            foreach (Reviews review in reviews)
            {
                Console.WriteLine($"|{review.Id}|{review.Rating}|{review.ReservationId}|");
            }
        }



        public void PracticeB1()
        {
            string query = @"SELECT * 
                            FROM Rooms 
                            WHERE has_internet = 1 AND has_tv = 1";

            List<Room> data = rooms.GetDataByQuery(query);
            PrintAllRooms(data);
        }

        public void PracticeB2()
        {
            string query = @"SELECT * 
                            FROM Reservations 
                            WHERE user_id = 1";

            List<Reservations> data = reservations.GetDataByQuery(query);
            PrintAllReservations(data);
        }

        public void PracticeB3()
        {
            string query = @"SELECT * 
                            FROM Users 
                            WHERE email_verified = 0";

            List<User> data = users.GetDataByQuery(query);
            PrintAllUsers(data);
        }

        public void PracticeB4(DateTime start_date, DateTime end_date)
        {
            List<dynamic> data = rooms.PracticeB4(start_date, end_date);

            foreach (dynamic obj in data)
            {
                Console.WriteLine($"|{obj.Id}|{obj.Type}|{obj.Start}|{obj.End}|{obj.Price}");
            }
        }

        public void PracticeB5()
        {
            int average = rooms.PracticeB5();
            Console.WriteLine(average);
        }

        public void PracticeC1(DateTime start_date, DateTime end_date)
        {
            int sum = reservations.PracticeC1(start_date, end_date);
            Console.WriteLine(sum);
        }

        public void PracticeC2(int min_price, int max_price)
        {
            string query = $@"SELECT *
                            FROM Rooms 
                            WHERE price BETWEEN '{min_price}' AND '{max_price}' ";

            List<Room> data = rooms.GetDataByQuery(query);
            PrintAllRooms(data);
        }

        public void PracticeC3()
        {
            var data = reviews.PracticeC3();

            foreach (dynamic obj in data)
            {
                Console.WriteLine($"|{obj.RoomId}|{obj.Count}|{obj.AvgRating}|");
            }
        }

        public void PracticeC4()
        {
            var data = rooms.PracticeC4();

            foreach (dynamic obj in data)
            {
                Console.WriteLine($"|{obj.Id}|{obj.Type}|{obj.MaxPrice}|");
            }
        }
    }
}
