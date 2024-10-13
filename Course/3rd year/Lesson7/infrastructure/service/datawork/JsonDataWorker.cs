using System.Globalization;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Lesson7;

public class JsonDataWorker
{
    public string filepath {get; set;}

    public JsonDataWorker(string path)
    {
        this.filepath = path;
    }
    public List<Book> ReadBookData()
    {
        using (FileStream fs = new FileStream(this.filepath, FileMode.OpenOrCreate))
        {
            List<Book> books = JsonSerializer.Deserialize<List<Book>>(fs);
            return books;
        }
    }

    public List<User> ReadUserData()
    {
        using (FileStream fs = new FileStream(this.filepath, FileMode.OpenOrCreate))
        {
            List<User> users = JsonSerializer.Deserialize<List<User>>(fs);
            return users;
        }
    }

    public void WriteBookData(List<Book> data)
    {
        var options3 = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };
        string json = JsonSerializer.Serialize<List<Book>>(data, options3);
        File.WriteAllText(this.filepath, json);
    }

    public void WriteUserData(List<User> data)
    {
        var options3 = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };
        string json = JsonSerializer.Serialize<List<User>>(data, options3);
        File.WriteAllText(this.filepath, json);
    }
}