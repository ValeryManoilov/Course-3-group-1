namespace Lesson7;

public interface IUserManager
{
    public abstract void CreateUser(string newUserName);
    public abstract void AddBookForUser(long userId, long bookId);
    public abstract void DeleteBookForUser(long userId, long bookId);
    public abstract void ResetUserBook(long userId, long bookId, string newName, string newAuthor);
    public abstract void DeleteUser(long userId);
    public abstract List<User> GetAllUsers();
    public abstract dynamic GetUserById(long userId);
}