using EFCoreMyApp.services.models;

namespace EFCoreMyApp.services.interfaces
{
    public interface ITaskManager
    {
        public void AddTask(TaskObject newTask);
        public dynamic DeleteTask(long id);
        public dynamic CompleteTask(long id);
        public dynamic GetTaskById(long id);
        public List<TaskObject> GetAllTasks();
    }
}
