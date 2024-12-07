using Microsoft.Data.Sqlite;

namespace Practice20.Tables
{
    public class StudentTable
    {
        private readonly string _path;

        public StudentTable() { }

        public StudentTable(string path)
        {
            _path = path;
        }

        public void CreateTable()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"CREATE TABLE IF NOT EXISTS Students(
                                 id INT PRIMARY KEY NOT NULL,
                                 student_name TEXT)";


                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddStudents()
        {
            using(SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();
                string query = @"INSERT INTO Students(id, student_name) VALUES
                                    (1, 'Alice Johnson'),
                                    (2, 'Bob Smith'),
                                    (3, 'Charlie Brown'),
                                    (4, 'Diana Prince'),
                                    (5, 'Ethan Hunt'),
                                    (6, 'Fiona Gallagher'),
                                    (7, 'George Costanza'),
                                    (8, 'Hannah Baker'),
                                    (9, 'Isaac Newton'),
                                    (10, 'Julia Roberts'),
                                    (11, 'Kevin Spacey'),
                                    (12, 'Lisa Simpson'),
                                    (13, 'Michael Scott'),
                                    (14, 'Nina Williams'),
                                    (15, 'Oliver Twist')";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void GetAllStudents()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"SELECT * FROM Students";

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

                string query = @"DROP TABLE Students";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void PracticeB3()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"DELETE FROM Students WHERE id = 2";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }

                GetAllStudents();
            }
        }

        public void PracticeC1()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"SELECT s.student_name, c.class_name
                                 FROM Students AS s
                                 LEFT JOIN StudentClasses AS sc ON s.id = sc.student_id
                                 LEFT JOIN Classes AS c ON sc.class_id = c.id";

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

        public void PracticeC3()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"SELECT s.student_name, COUNT(c.class_name)
                                 FROM Students AS s
                                 LEFT JOIN StudentClasses AS sc ON s.id = sc.student_id
                                 LEFT JOIN Classes AS c ON sc.class_id = c.id
                                 GROUP BY s.student_name";

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
