using Microsoft.Data.Sqlite;

namespace Practice20.Tables
{
    public class ClassTable
    {
        private readonly string _path;

        public ClassTable() { }

        public ClassTable(string path)
        {
            _path = path;
        }

        public void CreateTable()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"CREATE TABLE IF NOT EXISTS Classes(
                                 id INT PRIMARY KEY NOT NULL,
                                 class_name TEXT)";


                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddClasses()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();
                string query = @"INSERT INTO Classes(id, class_name) VALUES
                                    (1, '7A'),
                                    (2, '7B'),
                                    (3, '8A'),
                                    (4, '8B'),
                                    (5, '9A')";
                using(SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void GetAllClasses()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"SELECT * FROM Classes";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    var data = command.ExecuteReader();

                    while (data.Read())
                    {
                        Console.WriteLine($"{data[0]} - {data[1]}");
                    }
                }
            }
        }

        public void Drop()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"DROP TABLE Classes";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
