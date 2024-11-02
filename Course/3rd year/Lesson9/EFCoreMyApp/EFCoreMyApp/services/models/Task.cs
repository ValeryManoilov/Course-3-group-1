using System.ComponentModel.DataAnnotations;

namespace EFCoreMyApp.services.models
{
    public class TaskObject
    {
        public long Id { get; set; } 
        public string TaskName { get; set; }
        public bool IsCompleted { get; set; }
        public TaskObject() { }
        public TaskObject(long id, string name, bool comp)
        {  
            Id = id;
            TaskName = name;
            IsCompleted = comp;
        }
    }
}
