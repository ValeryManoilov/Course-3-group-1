namespace MyPractice;
using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        Student[] students = Database.GetStudents();

        Course[] courses = Database.GetCourses();

        // Задача 5

        Console.WriteLine("Первоначальный список курсов:");
        Console.WriteLine("CourseId | CourseName | TeacherFullName");
        foreach(var course in courses)
        {
            Console.WriteLine($"{course.CourseId} | {course.CourseName} | {course.TeacherFullName}");
        }

        Console.WriteLine("\nСписок курсов без дубликатов");
        Console.WriteLine("CourseId | CourseName | TeacherFullName");
        var PracticeE = courses.Distinct();
        foreach(var course in PracticeE)
        {
            Console.WriteLine($"{course.CourseId} | {course.CourseName} | {course.TeacherFullName}");
        }

        // Задача 1
        var query = students.Join(courses,
                        s => s.CourseId,
                        c => c.CourseId,
                        (s, c) => new {Id = s.StudentId, Name = s.StudentName, Degreeds = s.Degreeds, Course = c.CourseName});

        Console.WriteLine("\nСоединение двух списков по ключу");
        Console.WriteLine("Id | Name | Degreeds | Course");

        foreach(var obj in query)
        {
            Console.WriteLine($"{obj.Id} | {obj.Name} | {string.Join(", ", obj.Degreeds)} | {obj.Course}");
        }
        
        // Задача 2

        Console.WriteLine("\nГруппировка двух списков по названию курса");
        Console.WriteLine("Course | Names");
        var PracticeB = query.GroupBy(c => c.Course,
                                    c => c.Name,
                                    (course, name) => new {Course = course, Name = name.ToList()});
        foreach(var obj in PracticeB)
        {
            Console.WriteLine($"{obj.Course} | {string.Join(", ", obj.Name.ToList())}");
        }

        // Задача 3

        Console.WriteLine("\nОбщая сумма всех оценок:");
        var PracticeC = query.Sum(t => t.Degreeds.Sum());
        Console.WriteLine(PracticeC);

        // Задача 4

        Console.WriteLine("\nСреднее арифметическое всех оценок:");
        var PracticeD = query.Average(t => t.Degreeds.Average());
        Console.WriteLine(PracticeD);
    }
}