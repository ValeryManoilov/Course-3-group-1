using EFCoreMyApp.services.implementations;
using EFCoreMyApp.services.interfaces;
using EFCoreMyApp.services.models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;



namespace EFCoreMyApp.services.controllers
{
    [Route("/api/")]
    public class TaskController : ControllerBase
    {
        private readonly TaskManager _tasks;
        public TaskController(TaskManager tasks)
        {
            _tasks = tasks;
        }

        [HttpGet("tasks/getall")]
        public List<TaskObject> GetAllTasks()
        {
            return _tasks.GetAllTasks();
        }

        [HttpGet]
        [Route("/tasks/get/{id}")]
        public IActionResult GetTaskById(long id)
        {
            TaskObject needTask = _tasks.GetTaskById(id);
            if (needTask != null)
            {
                return Ok(needTask);
            }
            return NotFound("Задача не найдена");
        }

        [HttpGet]
        [Route("/tasks/complete/{id}")]
        public IActionResult CompleteTask(long id)
        {
            TaskObject needTask = _tasks.GetTaskById(id);
            if (needTask != null)
            {
                _tasks.CompleteTask(id);
                return Ok(needTask);
            }
            return NotFound("Задача не найдена");
        }

        [HttpPost]
        [Route("/tasks/add")]
        public IActionResult AddTask([FromBody] TaskObject task)
        {
            _tasks.AddTask(task);
            return Ok(_tasks.GetAllTasks());
        }

        [HttpDelete]
        [Route("/tasks/delete/{id}")]
        public IActionResult DeleteTask(long id)
        {
            TaskObject needTask = _tasks.GetTaskById(id);
            if (needTask != null)
            {
                _tasks.DeleteTask(id);      
                return Ok(_tasks.GetAllTasks());
            }
            return NotFound("Задача не найдена");
        }
    }
}
