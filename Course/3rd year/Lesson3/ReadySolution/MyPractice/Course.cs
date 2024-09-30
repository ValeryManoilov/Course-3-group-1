namespace MyPractice;
public class Course
{
    public long CourseId {get;set;}
    public string CourseName {get;set;}
    public string TeacherFullName {get; set;}    
    public Course () { }
    public Course (long id, string cname, string tfn)
    {
        this.CourseId = id;
        this.CourseName = cname;
        this.TeacherFullName = tfn;
    }
}