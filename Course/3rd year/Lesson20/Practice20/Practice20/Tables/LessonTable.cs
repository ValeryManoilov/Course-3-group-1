using Microsoft.Data.Sqlite;

namespace Practice20.Tables
{
    public class LessonTable
    {
        private readonly string _path;

        public LessonTable() { }

        public LessonTable(string path)
        {
            _path = path;
        }

        public void CreateTable()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"CREATE TABLE IF NOT EXISTS Lessons(
                                 id INT PRIMARY KEY NOT NULL,
                                 lesson_time DATETIME,
                                 class_id INT,
                                 teacher_id INT,
                                 subject_id INT,
                                 FOREIGN KEY (class_id) REFERENCES Classes (id) ON DELETE CASCADE,
                                 FOREIGN KEY (teacher_id) REFERENCES Teachers (id) ON DELETE CASCADE,
                                 FOREIGN KEY (subject_id) REFERENCES Subjects (id) ON DELETE CASCADE)";


                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public void AddLessons()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();
                string query = @"INSERT INTO Lessons(id, lesson_time, class_id, teacher_id, subject_id) VALUES
                                    (1, '08:00', 1, 1, 1),
                                    (2, '09:00', 1, 2, 2),
                                    (3, '10:00', 1, 3, 3),
                                    (4, '11:00', 1, 4, 4),
                                    (5, '12:00', 1, 5, 5),
                                    (6, '13:00', 1, 6, 6),
                                    (7, '14:00', 1, 7, 7),
                                    (8, '08:00', 2, 8, 8),
                                    (9, '09:15', 2, 9, 9),
                                    (10, '10:30', 2, 10, 10),
                                    (11, '11:45', 2, 11, 11),
                                    (12, '12:50', 2, 12, 12),
                                    (13, '13:55', 2, 13, 13),
                                    (14, '14:10', 2, 14, 14),
                                    (15, '08:00', 3, 15, 15),
                                    (16, '09:20', 3, 1, 1),
                                    (17, '10:40', 3, 2, 2),
                                    (18, '11:00', 3, 3, 3),
                                    (19, '12:30', 3, 4, 4),
                                    (20, '13:50', 3, 5, 5),
                                    (21, '14:15', 3, 6, 6),
                                    (22, '08:00', 4, 7, 7),
                                    (23, '09:05', 4, 8, 8),
                                    (24, '10:15', 4, 9, 9),
                                    (25, '11:25', 4, 10, 10),
                                    (26, '12:35', 4, 11, 11),
                                    (27, '13:45', 4, 12, 12),
                                    (28, '14:50', 4, 13, 13),
                                    (29, '08:00', 5, 14, 14),
                                    (30, '09:10', 5, 15, 15),
                                    (31, '10:20', 5, 1, 1),
                                    (32, '11:30', 5, 2, 2),
                                    (33, '12:40', 5, 3, 3),
                                    (34, '13:50', 5, 4, 4),
                                    (35, '14:00', 5, 5, 5)";


                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Drop()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"DROP TABLE Lessons";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void GetAllLessons()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"SELECT * FROM Lessons";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    var data = command.ExecuteReader();

                    while (data.Read())
                    {
                        Console.WriteLine($"{data[0]} - {data[1]} - {data[2]} - {data[3]} - {data[4]}");
                    }
                }
            }
        }

        public void PracticeB2()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                //Я хотел использовать этот код, но он не работает как надо. Он должен
                //заменять математику на другой предмет, но в итоге заменяет вообще все предметы

                //string query = @"UPDATE Lessons
                //                 SET subject_id = 8
                //                 WHERE class_id = 4 AND subject_id IN
                //                    (SELECT subject_id
                //                     FROM Subjects
                //                     WHERE subject_name = 'Mathematics')";


                string query = @"UPDATE Lessons
                                 SET subject_id = 8
                                 WHERE class_id = 4 AND subject_id = 1";


                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }

                string query2 = @"SELECT l.lesson_time, c.class_name, s.subject_name
                                 FROM Lessons AS l
                                 LEFT JOIN Classes AS c ON l.class_id = c.id
                                 LEFT JOIN Subjects AS s ON l.subject_id = s.id
                                 WHERE c.id = 4";

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

        public void PracticeB4()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                //Я хотел использовать этот код, но он не работает как надо. Он должен
                //заменять математику на другой предмет, но в итоге заменяет вообще все предметы

                //string query = @"UPDATE Lessons
                //                 SET subject_id = 8
                //                 WHERE class_id = 4 AND subject_id IN
                //                    (SELECT subject_id
                //                     FROM Subjects
                //                     WHERE subject_name = 'Mathematics')";


                string query = @"DELETE FROM Lessons WHERE class_id = 2 AND subject_id = 2";


                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }

                string query2 = @"SELECT l.lesson_time, c.class_name, s.subject_name
                                 FROM Lessons AS l
                                 LEFT JOIN Classes AS c ON l.class_id = c.id
                                 LEFT JOIN Subjects AS s ON l.subject_id = s.id
                                 WHERE c.id = 2";

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

        public void PracticeC2()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query2 = @"SELECT l.lesson_time, c.class_name, s.subject_name
                                 FROM Lessons AS l
                                 LEFT JOIN Classes AS c ON l.class_id = c.id
                                 LEFT JOIN Subjects AS s ON l.subject_id = s.id
                                 WHERE c.id = 4";

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
