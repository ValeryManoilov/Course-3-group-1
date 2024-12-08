using Practice20.Tables;
using SQLitePCL;


namespace Practice20
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Ссылка на ER-диаграмму
            // https://dbdiagram.io/d/674226fbe9daa85aca7af76d
            
            SQLitePCL.Batteries.Init();

            string path = "Data Source=data.db";
            StudentClassTable scTable = new StudentClassTable(path);
            ClassTable classTable = new ClassTable(path);
            StudentTable studentTable = new StudentTable(path);
            LessonTable lessonTable = new LessonTable(path);
            TeacherTable teacherTable = new TeacherTable(path);
            SubjectTable subjectTable = new SubjectTable(path);
            ScheduleTable scheduleTable = new ScheduleTable(path);

            //teacherTable.PracticeB1();
            //lessonTable.PracticeB2();
            //studentTable.PracticeB3();
            //lessonTable.PracticeB4();
            //scTable.PracticeB5();

            //studentTable.PracticeC1();
            //lessonTable.PracticeC2();
            //studentTable.PracticeC3();
        }
    }
}
