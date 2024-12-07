using Microsoft.Data.Sqlite;

namespace Practice20.Tables
{
    public class SubjectTable
    {
        private readonly string _path;

        public SubjectTable() { }

        public SubjectTable(string path)
        {
            _path = path;
        }

        public void CreateTable()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"CREATE TABLE IF NOT EXISTS Subjects(
                                 id INT PRIMARY KEY NOT NULL,
                                 subject_name TEXT)";


                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddSubjects()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();
                string query = @"INSERT INTO Subjects(id, subject_name) VALUES
                                    (1, 'Mathematics'),
                                    (2, 'Physics'),
                                    (3, 'Chemistry'),
                                    (4, 'Biology'),
                                    (5, 'History'),
                                    (6, 'English Literature'),
                                    (7, 'Computer Science'),
                                    (8, 'Art History'),
                                    (9, 'Psychology'),
                                    (10, 'Philosophy'),
                                    (11, 'Economics'),
                                    (12, 'Political Science'),
                                    (13, 'Geography'),
                                    (14, 'Sociology'),
                                    (15, 'Astronomy')";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public void GetAllSubjects()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"SELECT * FROM Subjects";

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
    }
}
