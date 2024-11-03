using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.GetEncoding("utf-16");
        object locker = new();
        string path = "output.txt";
        string symbols = Console.ReadLine();

        while (symbols != "exit")
        {
            WriteInFile(symbols);
            symbols = Console.ReadLine();
        }

        async Task WriteInFile(string symbols)
        {
            lock (locker)
            {
                using (var sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(symbols);
                }
            }
        }
    }
}