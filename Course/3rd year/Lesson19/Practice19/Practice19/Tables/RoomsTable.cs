using Microsoft.Data.Sqlite;
using Practice19.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice19.Tables
{
    public class RoomsTable
    {
        private static string _connectionString;

        public RoomsTable(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateTable()
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                //end_date забыл удалить при создании таблицы, его здесь быть не должно :)
                var query = @"CREATE TABLE IF NOT EXISTS Rooms (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    home_type TEXT NOT NULL,
                    address TEXT NOT NULL,
                    has_tv INTEGER NOT NULL,
                    has_internet INTEGER NOT NULL,
                    has_kitchen INTEGER NOT NULL,
                    has_air_con INTEGER NOT NULL,
                    end_date TEXT NOT NULL,
                    price INTEGER NOT NULL,
                    latitude INTEGER NOT NULL,
                    owner_id INTEGER NOT NULL,
                    longitude INTEGER NOT NULL,
                    FOREIGN KEY (owner_id) REFERENCES Users (id) ON DELETE CASCADE)";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddRooms()
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO Rooms(id, home_type, address, has_tv, has_internet, has_kitchen, has_air_con, end_date, price, latitude, longitude, owner_id)
                                Values (11, 'Apartment', '808 Pine St', 1, 0, 0, 1, '2025-01-15', 160, 40.7306, -73.9352, 1),
                                        (12, 'House', '909 Maple Blvd', 0, 1, 1, 0, '2025-02-20', 210, 34.0522, -118.2437, 2),
                                        (13, 'Condo', '1010 Oak Ave', 1, 1, 1, 1, '2024-05-30', 130, 51.5074, -0.1278, 3),
                                        (14, 'Studio', '1111 Cedar St', 1, 1, 0, 1, '2024-08-25', 95, 48.8566, 2.3522, 4),
                                        (15, 'Villa', '1212 Birch Rd', 0, 0, 1, 1, '2025-03-30', 350, 40.7128, -74.0060, 5),
                                        (16, 'Cottage', '1313 Elm St', 1, 1, 1, 0, '2024-12-10', 150, 35.6895, 139.6917, 6),
                                        (17, 'Loft', '1414 Walnut St', 1, 1, 0, 0, '2024-10-05', 120, 55.7558, 37.6173, 7),
                                        (18, 'Townhouse', '1515 Maple Ave', 0, 1, 1, 1, '2025-06-15', 270, 39.9042, 116.4074, 8),
                                        (19, 'Penthouse', '1616 Cedar Blvd', 1, 0, 1, 1, '2025-04-25', 600, 45.4215, -75.6972, 9),
                                        (20, 'Garage', '1717 Birch St', 0, 0, 0, 0, '2024-11-21', 60, 30.0444, 31.2357, 10),
                                        (21, 'Apartment', '1818 Chestnut St', 1, 1, 1, 0, '2025-03-15', 170, 40.7128, -74.0060, 1),
                                        (22, 'House', '1919 Redwood Ave', 0, 1, 1, 1, '2025-05-20', 240, 34.0522, -118.2437, 2),
                                        (23, 'Condo', '2020 Poplar St', 1, 1, 1, 0, '2024-09-15', 140, 51.5074, -0.1278, 3),
                                        (24, 'Studio', '2121 Willow Dr', 0, 1, 0, 1, '2024-10-25', 85, 48.8566, 2.3522, 4),
                                        (25, 'Villa', '2222 Pinecrest Ln', 0, 1, 1, 1, '2025-01-20', 330, 40.7306, -73.9352, 5),
                                        (26, 'Cottage', '2323 Larch St', 1, 1, 0, 0, '2024-06-07', 160, 35.6895, 139.6917, 6),
                                        (27, 'Loft', '2424 Maple Blvd', 1, 1, 1, 1, '2024-11-15', 140, 55.7558, 37.6173, 7),
                                        (28, 'Townhouse', '2525 Hickory Ln', 1, 0, 1, 0, '2025-10-30', 250, 39.9042, 116.4074, 8),
                                        (29, 'Penthouse', '2626 Acacia St', 1, 1, 1, 1, '2025-02-10', 480, 45.4215, -75.6972, 9),
                                        (30, 'Garage', '2727 Pine St', 0, 0, 0, 0, '2024-10-01', 50, 30.0444, 31.2357, 10)";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Room> GetDataByQuery(string query)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    List<Room> rooms = new List<Room>();

                    var data = command.ExecuteReader();
                    while (data.Read())
                    {
                        rooms.Add(new Room(Convert.ToInt32(data[0]), Convert.ToString(data[1]), Convert.ToString(data[2]),
                            Convert.ToInt32(data[3]), Convert.ToInt32(data[4]), Convert.ToInt32(data[5]), Convert.ToInt32(data[6]),
                            Convert.ToString(data[7]), Convert.ToInt32(data[8]), Convert.ToInt32(data[9]), Convert.ToInt32(data[10]),
                            Convert.ToInt32(data[11])));
                    }
                    return rooms;
                }
            }
        }

        public List<dynamic> PracticeB4(DateTime start_date, DateTime end_date)
        {
            string start = start_date.ToString("yyyy-MM-dd");
            string end = end_date.ToString("yyyy-MM-dd");
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string query = $@"SELECT rooms.Id, rooms.home_type, res.start_date, res.end_date, res.price
                            FROM Rooms AS rooms
                            LEFT JOIN Reservations AS res ON rooms.Id = res.room_id
                            WHERE res.start_date BETWEEN @start AND @end";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@start", start);
                    command.Parameters.AddWithValue("@end", end);

                    List<dynamic> needRooms = new List<dynamic>();

                    var data = command.ExecuteReader();
                    while (data.Read())
                    {
                        needRooms.Add(new { Id = Convert.ToInt32(data[0]), Type = Convert.ToString(data[1]), Start = Convert.ToDateTime(data[2]), End = Convert.ToDateTime(data[3]), Price = Convert.ToInt32(data[4]) });
                    }
                    return needRooms;
                }
            }
        }

        public int PracticeB5()
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string query = $@"SELECT AVG(Price)
                                  FROM Rooms";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    int avprice = 0;
                    var data = command.ExecuteReader();
                    while (data.Read())
                    {
                        avprice = Convert.ToInt32(data[0]);
                    }
                    return avprice;
                }
            }
        }

        public List<dynamic> PracticeC4()
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                string query = $@"SELECT *
                                  FROM Rooms
                                  WHERE price IN (SELECT MAX(price) FROM Rooms GROUP BY home_type)";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    List<dynamic> rooms = new List<dynamic>();

                    var data = command.ExecuteReader();
                    while (data.Read())
                    {
                        rooms.Add(new { Id = Convert.ToInt32(data[0]), Type = Convert.ToString(data[1]), MaxPrice = Convert.ToInt32(data[2]) });
                    }
                    return rooms;
                }
            }
        }
    }
}
