using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Practice19.Models;


namespace Practice19.Tables
{
    public class ReviewsTable
    {
        private static string _connectionString;

        public ReviewsTable(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateTable()
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var query = @"CREATE TABLE IF NOT EXISTS Reviews (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    reservation_id INTEGER NOT NULL,
                    rating INTEGER NOT NULL,
                    FOREIGN KEY (reservation_id) REFERENCES Reservations (id))";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddReviews()
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO Reviews(id, reservation_id, rating)
                                Values(11, 1, 4),
                                        (12, 2, 5),
                                        (13, 3, 3),
                                        (14, 4, 2),
                                        (15, 5, 1),
                                        (16, 6, 5),
                                        (17, 7, 4),
                                        (18, 8, 3),
                                        (19, 9, 2),
                                        (20, 10, 1)";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Reviews> GetDataByQuery(string query)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    List<Reviews> reviews = new List<Reviews>();

                    var data = command.ExecuteReader();
                    while (data.Read())
                    {
                        reviews.Add(new Reviews(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]), Convert.ToInt32(data[2])));
                    }
                    return reviews;
                }
            }
        }

        public List<dynamic> PracticeC3()
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string query = @"SELECT res.room_id, COUNT(*), AVG(rating)
                                 FROM Reviews AS rev
                                 LEFT JOIN Reservations AS res ON rev.reservation_id = res.id
                                 GROUP BY res.room_id";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    List<dynamic> reviews = new List<dynamic>();

                    var data = command.ExecuteReader();
                    while (data.Read())
                    {
                        reviews.Add(new { RoomId = Convert.ToInt32(data[0]), Count = Convert.ToInt32(data[1]), AvgRating = Convert.ToInt32(data[2]) });
                    }
                    return reviews;
                }
            }
        }
    }
}
