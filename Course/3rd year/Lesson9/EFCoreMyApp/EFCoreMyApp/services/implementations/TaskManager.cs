using EFCoreMyApp.services.context;
using EFCoreMyApp.services.interfaces;
using EFCoreMyApp.services.models;


namespace EFCoreMyApp.services.implementations
{
    public class TaskManager : ITaskManager
    {
        private readonly TaskContext _tasks;
        public TaskManager(TaskContext tasks)
        {
            _tasks = tasks;
        }

        public void AddTask(TaskObject newTask)
        {
            _tasks.Tasks.Add(newTask);
            _tasks.SaveChanges();
        }

        public TaskObject DeleteTask(long id)
        {
            TaskObject needTask = GetTaskById(id);
            if (needTask != null)
            {
                _tasks.Tasks.Remove(needTask);
                _tasks.SaveChanges();
            }
            return needTask;
        }

        public TaskObject CompleteTask(long id)
        {
            TaskObject needTask = GetTaskById(id);
            if (needTask != null)
            {
                needTask.IsCompleted = true;
                _tasks.SaveChanges();
            }
            return needTask;
        }

        public TaskObject GetTaskById(long id)
        {
            TaskObject needTask = _tasks.Tasks.FirstOrDefault(task => task.Id == id);
            return needTask;
        }

        public List<TaskObject> GetAllTasks()
        {
            return _tasks.Tasks.ToList();
        }
    }
}
