namespace Lesson7;

[Serializable]
public class User
{
    public long UserId {get;set;}
    public string UserName {get;set;}
    public List<Book> UserBooks {get;set;}
    public User() { }
    public User(long id, string uname, List<Book> books)
    {
        this.UserId = id;
        this.UserName = uname;
        this.UserBooks = books;
    }
}