namespace MyPractice;
public class Student
{
    public long StudentId {get; set;}
    public string StudentName {get; set;}
    public int[] Degreeds {get; set;}
    public long CourseId {get; set;}
    public Student() { }
    public Student(long id, string sname, int[] degreeds, long cid)
    {   
        this.StudentId = id;
        this.StudentName = sname;
        this.Degreeds = degreeds;
        this.CourseId = cid;
    }
}