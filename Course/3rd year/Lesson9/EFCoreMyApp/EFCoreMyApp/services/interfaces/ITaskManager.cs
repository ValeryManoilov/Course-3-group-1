using EFCoreMyApp.services.models;

namespace EFCoreMyApp.services.interfaces
{
    public interface ITaskManager
    {
        public void AddTask(TaskObject newTask);
        public TaskObject DeleteTask(long id);
        public TaskObject CompleteTask(long id);
        public TaskObject GetTaskById(long id);
        public List<TaskObject> GetAllTasks();
    }
}
