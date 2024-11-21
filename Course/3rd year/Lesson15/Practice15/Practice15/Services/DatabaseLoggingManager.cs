using Practice15.Data;
using Practice15.Interfaces;
using Practice15.Models;

namespace Practice15.Services
{
    public class DatabaseLoggingManager : ILoggingManager
    {
        private readonly NoteContext _logs;
        public DatabaseLoggingManager(NoteContext logs)
        {
            _logs = logs;
        }
        public void Logging(string logMessage)
        {
            var newLog = new LogObject(logMessage);
            _logs.Logs.Add(newLog);
            _logs.SaveChanges();
        }
        
        public List<LogObject> GetAllLogs()
        {
            return _logs.Logs.ToList();
        }
    }
}
