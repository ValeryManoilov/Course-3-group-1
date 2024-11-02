namespace ManyAsyncApps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object locker = new ();
            string path = "output.txt";

            async Task WriteFile(string path)
            {
                lock (locker)
                {
                    string data= "";
                    using(StreamWriter stream = new StreamWriter(path, true))
                    {
                        while (data != "exit")
                        {
                            stream.WriteLine(data);
                            data = Console.ReadLine();
                        }
                    }
                }
            }
            WriteFile(path);
        }
    }
}
