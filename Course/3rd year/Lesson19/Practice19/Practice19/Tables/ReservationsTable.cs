using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice19.Models;
using System.Collections;

namespace Practice19.Tables
{
    public class ReservationsTable
    {
        private static string _connectionString;

        public ReservationsTable(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateTable()
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var query = @"CREATE TABLE IF NOT EXISTS Reservations (
                    id INTEGER PRIMARY KEY AUTOINCREMENT, 
                    user_id INTEGER NOT NULL,
                    room_id INTEGER NOT NULL,
                    start_date TEXT NOT NULL,
                    end_date TEXT NOT NULL,
                    price INTEGER NOT NULL,
                    total INTEGER NOT NULL,
                    FOREIGN KEY(user_id) REFERENCES Users(id),
                    FOREIGN KEY(room_id) REFERENCES Rooms(id))";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddReservations()
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO Reservations(id, user_id, room_id, start_date, end_date, price, total)
                                Values (1, 1, 3, '2024-01-05', '2024-01-10', 500, 2500),
                                        (2, 2, 1, '2024-02-15', '2024-02-20', 300, 1500),
                                        (3, 3, 5, '2024-03-10', '2024-03-12', 200, 400),
                                        (4, 4, 2, '2024-04-20', '2024-04-25', 600, 3000),
                                        (5, 5, 4, '2024-05-05', '2024-05-10', 400, 2000),
                                        (6, 6, 8, '2024-06-01', '2024-06-06', 350, 1750),
                                        (7, 7, 9, '2024-07-15', '2024-07-20', 450, 2250),
                                        (8, 8, 7, '2024-08-10', '2024-08-15', 550, 2750),
                                        (9, 9, 6, '2024-09-01', '2024-09-05', 300, 1500),
                                        (10, 10, 10, '2024-10-20', '2024-10-25', 220, 1100)";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Reservations> GetDataByQuery(string query)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    List<Reservations> reservations = new List<Reservations>();

                    var data = command.ExecuteReader();
                    while (data.Read())
                    {
                        reservations.Add(new Reservations(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]),
                                                            Convert.ToInt32(data[2]), Convert.ToString(data[3]),
                                                            Convert.ToString(data[3]), Convert.ToInt32(data[5]),
                                                            Convert.ToInt32(data[6])));
                    }
                    return reservations;
                }
            }
        }

        public int PracticeC1(DateTime start_date, DateTime end_date)
        {
            string start = start_date.ToString("yyyy-MM-dd");
            string end = end_date.ToString("yyyy-MM-dd");

            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string query = @"SELECT SUM(Price)
                                FROM Reservations
                                WHERE start_date BETWEEN @start AND @end";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@start", start);
                    command.Parameters.AddWithValue("@end", end);
                    int sum = 0;
                    var data = command.ExecuteReader();
                    while (data.Read())
                    {
                        sum = Convert.ToInt32(data[0]);
                    }
                    return sum;
                }
            }
        }
    }
}
