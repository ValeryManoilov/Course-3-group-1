using Practice15.Interfaces;

namespace Practice15.Services
{
    public class ConsoleLoggingManager : ILoggingManager
    {
        public void Logging(string logMessage)
        {
            Console.WriteLine(logMessage);
        }
    }
}
