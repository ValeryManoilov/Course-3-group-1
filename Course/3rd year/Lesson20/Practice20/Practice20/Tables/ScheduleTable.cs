using Microsoft.Data.Sqlite;

namespace Practice20.Tables
{
    public class ScheduleTable
    {
        private readonly string _path;

        public ScheduleTable() { }

        public ScheduleTable(string path)
        {
            _path = path;
        }

        public void CreateTable()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();

                string query = @"CREATE TABLE IF NOT EXISTS Schedules(
                                 id INT PRIMARY KEY NOT NULL,
                                 schedule_date DATETIME,
                                 lesson_id INT,
                                 FOREIGN KEY (lesson_id) REFERENCES Lessons (id) ON DELETE CASCADE)";


                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public void AddSchedules()
        {
            using (SqliteConnection connection = new SqliteConnection(_path))
            {
                connection.Open();
                string query = @"INSERT INTO Schedules(id, schedule_date, lesson_id) VALUES
                                    ";
            }
        }
    }
}
