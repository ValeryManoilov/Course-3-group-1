namespace Practice15.Models
{
    public class LogObject
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string LogText { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public LogObject() { }
        public LogObject(string text)
        {
            LogText = text;
        }
    }
}
