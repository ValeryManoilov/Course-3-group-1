namespace Lesson7;

[Serializable]
public class Book
{
    public long BookId {get;set;}
    public string BookName {get;set;}
    public string AuthorName {get;set;}
    public Book() { }
    public Book(long id, string bname, string aname)
    {
        this.BookId = id;
        this.BookName = bname;
        this.AuthorName = aname;
    }
}