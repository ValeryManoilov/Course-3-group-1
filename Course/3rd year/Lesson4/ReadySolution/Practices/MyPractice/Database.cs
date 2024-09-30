namespace MyPractice;
using System;
using System.Collections.Generic;
public class Database
{
    public static Student Student1 = new Student{ StudentId = 1, StudentName = "Mark", Degreeds = new int[]{65, 51, 46, 66, 54}, CourseId = 1 };
    public static Student Student2 = new Student{ StudentId = 2, StudentName = "Jonh", Degreeds = new int[]{89, 77, 94, 98, 85}, CourseId = 7 };
    public static Student Student3 = new Student{ StudentId = 3, StudentName = "Anthony", Degreeds = new int[]{34, 43, 41, 52, 36}, CourseId = 3 };
    public static Student Student4 = new Student{ StudentId = 4, StudentName = "Michael", Degreeds = new int[]{54, 56, 67, 49, 60}, CourseId = 2 };
    public static Student Student5 = new Student{ StudentId = 5, StudentName = "Henry", Degreeds = new int[]{99, 94, 100, 89, 91}, CourseId = 8 };
    public static Student Student6 = new Student{ StudentId = 6, StudentName = "Thomas", Degreeds = new int[]{27, 34, 27, 30, 41}, CourseId = 5 };
    public static Student Student7 = new Student{ StudentId = 7, StudentName = "Roy", Degreeds = new int[]{76, 81, 78, 72, 76}, CourseId = 9 };
    public static Student Student8 = new Student{ StudentId = 8, StudentName = "Oliver", Degreeds = new int[]{90, 92, 84, 95, 99}, CourseId = 4 };
    public static Student Student9 = new Student{ StudentId = 9, StudentName = "Andrew", Degreeds = new int[]{45, 32, 43, 42, 39}, CourseId = 6 };
    public static Student Student10 = new Student{ StudentId = 10, StudentName = "Donald", Degreeds = new int[]{78, 79, 69, 83, 75}, CourseId = 1 };
    public static Student Student11 = new Student{ StudentId = 11, StudentName = "Felix", Degreeds = new int[]{65, 51, 46, 66, 54}, CourseId = 10 };
    public static Student Student12 = new Student{ StudentId = 12, StudentName = "Lester", Degreeds = new int[]{89, 77, 94, 98, 85}, CourseId = 3 };
    public static Student Student13 = new Student{ StudentId = 13, StudentName = "Martin", Degreeds = new int[]{34, 43, 41, 52, 36}, CourseId = 7 };
    public static Student Student14 = new Student{ StudentId = 14, StudentName = "Oscar", Degreeds = new int[]{54, 56, 67, 49, 60}, CourseId = 2 };
    public static Student Student15 = new Student{ StudentId = 15, StudentName = "Tyler", Degreeds = new int[]{99, 94, 100, 89, 91}, CourseId = 6 };
    public static Student Student16 = new Student{ StudentId = 16, StudentName = "Travis", Degreeds = new int[]{27, 34, 27, 30, 41}, CourseId = 8 };
    public static Student Student17 = new Student{ StudentId = 17, StudentName = "Marcus", Degreeds = new int[]{76, 81, 78, 72, 76}, CourseId = 5 };
    public static Student Student18 = new Student{ StudentId = 18, StudentName = "Connor", Degreeds = new int[]{90, 92, 84, 95, 99}, CourseId = 9 };
    public static Student Student19 = new Student{ StudentId = 19, StudentName = "Lucas", Degreeds = new int[]{45, 32, 43, 42, 39}, CourseId = 4 };
    public static Student Student20 = new Student{ StudentId = 20, StudentName = "Jacob", Degreeds = new int[]{78, 79, 69, 83, 75}, CourseId = 10 };

    public static Course Course1 = new Course{ CourseId = 1, CourseName = "English", TeacherFullName = "James Monroe"};
    public static Course Course2 = new Course{ CourseId = 2, CourseName = "Science", TeacherFullName = "John Tyler" };
    public static Course Course3 = new Course{ CourseId = 3, CourseName = "Math", TeacherFullName = "Zachary Taylor" };
    public static Course Course4 = new Course{ CourseId = 4, CourseName = "Georgaphy", TeacherFullName = "Franklin Pierce" };
    public static Course Course5 = new Course{ CourseId = 5, CourseName = "Spanish", TeacherFullName = "Abraham Lincoln" };
    public static Course Course6 = new Course{ CourseId = 6, CourseName = "Astronomy", TeacherFullName = "Ulysses Grant" };
    public static Course Course7 = new Course{ CourseId = 7, CourseName = "Biology", TeacherFullName = "Grover Cleveland" };
    public static Course Course8 = new Course{ CourseId = 8, CourseName = "Chemistry", TeacherFullName = "Theodore Roosevelt" };
    public static Course Course9 = new Course{ CourseId = 9, CourseName = "IT", TeacherFullName = "Herbert Hoover" };
    public static Course Course10 = new Course{ CourseId = 10, CourseName = "Physics", TeacherFullName = "Richard Nixon" };


    public static Student[] students = new Student[]{ Student1, Student2, Student3, Student4, Student5, 
                                            Student6, Student7, Student8, Student9, Student10,
                                            Student11, Student12, Student13, Student14, Student15,
                                            Student16, Student17, Student18, Student19, Student20,};

    public static Course[] courses = new Course[]{Course1, Course2, Course3, Course4, Course5, 
                                        Course6, Course7, Course8, Course9, Course10,
                                        Course1, Course7, Course9};
    public static Course[] GetCourses()
    {
        return courses;
    }

    public static Student[] GetStudents()
    {
        return students;
    }
}