using EFCoreMyApp.services.context;
using EFCoreMyApp.services.interfaces;
using EFCoreMyApp.services.models;


namespace EFCoreMyApp.services.implementations
{
    public class TaskManager : ITaskManager
    {
        private readonly TaskContext _tasks;
        public TaskManager(TaskContext tasks) {
            _tasks = tasks;
        }

        public void AddTask(TaskObject newTask)
        {
            _tasks.Tasks.Add(newTask);
            _tasks.SaveChanges();
        }

        public dynamic DeleteTask(long id)
        {
            TaskObject needTask = _tasks.Tasks.FirstOrDefault(task => task.Id == id);
            if (needTask != null)
            {
                _tasks.Tasks.Remove(needTask);
                _tasks.SaveChanges();
                return needTask;
            }
            return null;
        }

        public dynamic CompleteTask(long id)
        {
            TaskObject needTask = _tasks.Tasks.FirstOrDefault(task => task.Id == id);
            if (needTask != null)
            {
                needTask.IsCompleted = true;
                _tasks.SaveChanges();
                return needTask;
            }
            return null;
        }

        public dynamic GetTaskById(long id) {
            TaskObject needTask = _tasks.Tasks.FirstOrDefault(task => task.Id == id);
            if (needTask != null)
            {
                return needTask;
            }
            return null;
        }

        public List<TaskObject> GetAllTasks()
        {
            return _tasks.Tasks.ToList();
        }
    }
}
