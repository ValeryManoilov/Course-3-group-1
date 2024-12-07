using Microsoft.Data.Sqlite;

namespace Practice20.Tables
{
    public class StudentClassTable
    {
        private readonly string _path;

        public StudentClassTable() { }

        public StudentClassTable(string path)
        {
            _path = path;
        }

        public void CreateTable()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"CREATE TABLE IF NOT EXISTS StudentClasses(
                                 student_id INT,
                                 class_id INT,
                                 FOREIGN KEY (student_id) REFERENCES Students (id) ON DELETE CASCADE,
                                 FOREIGN KEY (class_id) REFERENCES Classes (id) ON DELETE CASCADE)";


                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public void AddStudentClasses()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();
                string query = @"INSERT INTO StudentClasses(student_id, class_id) VALUES
                                    (1, 1),
                                    (3, 3),
                                    (4, 4),
                                    (5, 5),
                                    (6, 1),
                                    (7, 2),
                                    (8, 3),
                                    (9, 4),
                                    (10, 5),
                                    (11, 1),
                                    (12, 2),
                                    (13, 3),
                                    (14, 4),
                                    (15, 5);";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void GetAllStudentClasses()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"SELECT * FROM StudentClasses";

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

                string query = @"DROP TABLE StudentClasses";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void PracticeB5()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"UPDATE StudentClasses SET class_id = 3 WHERE student_id = 5";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }

                GetAllStudentClasses();
            }
        }
    }
}
