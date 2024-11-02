using EFCoreMyApp.services.interfaces;
using EFCoreMyApp.services.models;
using Microsoft.AspNetCore.Mvc;



namespace EFCoreMyApp.services.controllers
{
    [Route("/api/")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskManager _tasks;
        public TaskController(ITaskManager tasks)
        {
            _tasks = tasks;
        }

        [HttpGet("tasks/getall")]
        public IActionResult GetAllTasks()
        {
            return Ok(_tasks.GetAllTasks());
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
            TaskObject addingTask = _tasks.GetTaskById(task.Id);
            if (addingTask != null)
            {
                return BadRequest("Объект с таким id уже существует");
            }
            else
            {
                _tasks.AddTask(task);
                return Ok(_tasks.GetAllTasks());
            }
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
