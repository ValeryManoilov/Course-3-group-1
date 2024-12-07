using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice20.Tables
{
    public class TeacherTable
    {
        private readonly string _path;

        public TeacherTable() { }

        public TeacherTable(string path)
        {
            _path = path;
        }

        public void CreateTable()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"CREATE TABLE IF NOT EXISTS Teachers(
                                 id INT PRIMARY KEY NOT NULL,
                                 teacher_name TEXT,
                                 subject_id INT,
                                 FOREIGN KEY (subject_id) REFERENCES Subjects (id) ON DELETE CASCADE)";


                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddTeachers()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();
                string query = @"INSERT INTO Teachers(id, teacher_name, subject_id) VALUES
                                    (1, 'Mr. Smith', 1),
                                    (2, 'Ms. Johnson', 2),
                                    (3, 'Mrs. Brown', 3),
                                    (4, 'Mr. Williams', 4),
                                    (5, 'Ms. Jones', 5),
                                    (6, 'Mr. Garcia', 6),
                                    (7, 'Mrs. Martinez', 7),
                                    (8, 'Ms. Davis', 8),
                                    (9, 'Mr. Rodriguez', 9),
                                    (10, 'Mrs. Wilson', 10),
                                    (11, 'Ms. Anderson', 11),
                                    (12, 'Mr. Thomas', 12),
                                    (13, 'Mrs. Taylor', 13),
                                    (14, 'Mr. Lee', 14),
                                    (15, 'Mrs. Hernandez', 15)";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void GetAllTeachers()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"SELECT * FROM Teachers";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    var data = command.ExecuteReader();

                    while (data.Read())
                    {
                        Console.WriteLine($"{data[0]} - {data[1]} - {data[2]}");
                    }
                }
            }
        }

        public void Drop()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"DROP TABLE Teachers";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void GetAllTeachersSubs()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"SELECT t.teacher_name, s.subject_name
                                 FROM Teachers AS t
                                 LEFT JOIN Subjects AS s ON t.subject_id = s.id";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    var data = command.ExecuteReader();

                    while(data.Read())
                    {
                        Console.WriteLine($"{data[0]} - {data[1]}");
                    }
                }
            }
        }

        public void PracticeB1()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"UPDATE Teachers
                                 SET teacher_name = 'Mr. William'
                                 WHERE id = 2";

                using(SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }

                string query2 = @"SELECT * FROM Teachers WHERE id = 2";

                using (SqliteCommand command = new SqliteCommand(query2, connection))
                {
                    var data = command.ExecuteReader();

                    while (data.Read())
                    {
                        Console.WriteLine($"{data[0]} - {data[1]} - {data[2]}");
                    }
                }
            }
        }
    }
}
