using Microsoft.Data.Sqlite;
using System.Xml.Linq;
using SQLitePCL;
using System.Reflection.PortableExecutable;
namespace Practice18
{
    public class ContactRepository
    {
        private readonly string _connectionString;

        public ContactRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateTable()
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string query = @"CREATE TABLE IF NOT EXISTS Contacts (
                                   Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                   Name TEXT NOT NULL,
                                   Email TEXT NOT NULL,
                                   PhoneNumber TEXT NOT NULL
                               )";

                using (SqliteCommand command = new SqliteCommand(query, connection)) {
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Таблица создана");
        }

        public void DeleteContact(string name)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string query = @"DELETE FROM Contacts WHERE Name = @Name ";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddContact(string name, string email, string phoneNumber)
        {
            using(SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO Contacts(Name, Email, PhoneNumber)
                                 VALUES(@Name, @Email, @PhoneNumber)";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void GetAllContacts()
        {
            using(SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string query = @"SELECT * FROM Contacts";

                using(SqliteCommand command = new SqliteCommand(query, connection))
                {
                    var data = command.ExecuteReader();

                    while (data.Read())
                    {
                        Console.WriteLine(String.Format("{0} - {1} - {2} - {3}", data[0], data[1], data[2], data[3]));
                    }
                }
            }
        }

        public bool GetContactByName(string name)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string query = @"SELECT * FROM Contacts WHERE Name = @Name";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    var data = command.ExecuteReader();

                    if (data != null)
                    {
                        while (data.Read())
                        {
                            Console.WriteLine(String.Format("{0}-{1}-{2}-{3}", data[0], data[1], data[2], data[3]));
                            return true;
                        }
                    }
                    return false;
                }
            }
        }
    }
}
