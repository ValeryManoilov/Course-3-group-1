using System.Text;
using System.Threading;
using System.Threading.Tasks;
public class Program
{
    static async Task Main(string[] args)
    {
        object locker = new object();
        Console.InputEncoding = System.Text.Encoding.GetEncoding("utf-16");
        string path = "output.txt";

        List<string> data1 = ["apple", "banana", "orange"];
        List<string> data2 = ["tomato", "potato", "cucumber"];
        List<string> data3 = ["car", "yacht", "plane"];
        List<string> data4 = ["pen", "line", "eraser"];
        List<string> data5 = ["keyboard", "headphones", "mouse"];
        List<string> data6 = ["cup", "fork", "plate"];
        List<string> data7 = ["deer", "bear", "fox"];
        List<string> data8 = ["cat", "dog", "hamster"];


        List<List<string>> allData = [data1, data2, data3, data4, data5, data6, data7, data8];

        List<Task> tasks = new List<Task>();

        async Task SemaphoreFunc(List<List<string>> data)
        {
            SemaphoreSlim semaphore = new SemaphoreSlim(4, 4);
            for (int i = 0; i < 8; i++)
            {
                int index = i;
                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        semaphore.Wait();
                        Console.WriteLine($"Поток {Task.CurrentId} работает");
                        string objects = $"{Task.CurrentId}: {String.Join(", ", data[index])}";
                        await WriteInFileAsync(objects);
                        Console.WriteLine($"Поток {Task.CurrentId} освободился");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ошибка в {Task.CurrentId} потоке: {e.Message}");
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }));
            }

            await Task.WhenAll(tasks);

            Console.WriteLine("Cодержимое файла:");
            var FileData = ReadFromFileAsync();
            Console.WriteLine(FileData.Result.ToString());
        }

        async Task WriteInFileAsync(string symbols)
        {
            lock (locker)
            {
                using (var sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(symbols);
                }
            }
        }

        async Task<string> ReadFromFileAsync()
        {
            string data;
            lock (locker)
            {
                using (var stream = new StreamReader(path, true))
                {
                    data = stream.ReadToEndAsync().Result;
                }
            }
            return await Task.FromResult(data);
        }

        await SemaphoreFunc(allData);
    }
}