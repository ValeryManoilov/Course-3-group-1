using Practice19.Manager;
using Practice19.Models;
using SQLitePCL;
using System.IO;

namespace Practice19
{
    public class Program
    {
        static void Main(string[] args)
        {
            SQLitePCL.Batteries.Init();
            string path = "Data Source=data.db";
            TableManager manager = new TableManager();

            //Практика B

            //manager.PracticeB1();
            //manager.PracticeB2();
            //manager.PracticeB3();
            //manager.PracticeB4(new DateTime(2024, 02, 01), new DateTime(2024, 04, 30));
            //manager.PracticeB5();

            //Практика С
            //manager.PracticeC1(new DateTime(2024, 02, 01), new DateTime(2024, 04, 30));
            //manager.PracticeC2(100, 250);
            //manager.PracticeC3();
            //manager.PracticeC4();
        }
    }
}
