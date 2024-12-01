using Microsoft.Data.Sqlite;
using Practice19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice19.Tables
{
    public class UsersTable
    {
        private static string _connectionString;

        public UsersTable(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateTable()
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var query = @"CREATE TABLE IF NOT EXISTS Users (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL,
                    email TEXT NOT NULL,
                    email_verified INTEGER NOT NULL,
                    password TEXT NOT NULL,
                    phone TEXT NOT NULL
)";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddUsers()
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var query = @"INSERT INTO Users(id, name, email, email_verified, password, phone) Values
                            (1, 'John Doe', 'john.doe@example.com', 1, 'password123', '+1234567890'),
                            (2, 'Jane Smith', 'jane.smith@example.com', 1, 'password456', '+1234567891'),
                            (3, 'Michael Johnson', 'michael.johnson@example.com', 0, 'password789', '+1234567892'),
                            (4, 'Emily Davis', 'emily.davis@example.com', 1, 'securepass', '+1234567893'),
                            (5, 'William Brown', 'william.brown@example.com', 1, 'secretpass', '+1234567894'),
                            (6, 'Olivia Jones', 'olivia.jones@example.com', 0, 'passw0rd', '+1234567895'),
                            (7, 'James Garcia', 'james.garcia@example.com', 1, 'mypassword', '+1234567896'),
                            (8, 'Isabella Martinez', 'isabella.martinez@example.com', 1, 'lovelypass', '+1234567897'),
                            (9, 'Benjamin Rodriguez', 'benjamin.rodriguez@example.com', 0, 'pass456', '+1234567898'),
                            (10, 'Sophia Lewis', 'sophia.lewis@example.com', 1, 'strongpassword', '+1234567899')";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<User> GetDataByQuery(string query)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    List<User> users = new List<User>();

                    var data = command.ExecuteReader();
                    while (data.Read())
                    {
                        users.Add(new User(Convert.ToInt32(data[0]), Convert.ToString(data[1]), Convert.ToString(data[2]), Convert.ToInt32(data[3]), Convert.ToString(data[4]), Convert.ToString(data[5])));
                    }
                    return users;
                }
            }
        }
    }
}
