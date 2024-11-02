using EFCoreMyApp.services.controllers;
using EFCoreMyApp.services.interfaces;
using EFCoreMyApp.services.models;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreMyApp.Tests.EFCoreMyAppTests
{
    public class EFCoreMyAppTests
    {
        private TaskController _taskController;
        private readonly ITaskManager _tasks;

        public EFCoreMyAppTests()
        {
            _tasks = A.Fake<ITaskManager>();

            _taskController = new TaskController(_tasks);
        }

        [Fact]
        public void EFCoreMyApp_GetAllTasks_ReturnSuccess()
        {
            var fakeTasks = A.Fake<List<TaskObject>>();
            A.CallTo(() => _tasks.GetAllTasks()).Returns(fakeTasks);

            var result = _taskController.GetAllTasks();
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void EFCoreMyApp_GetTaskById_ReturnSuccess()
        {
            var fakeTaskId = 3;
            var fake = A.Fake<TaskObject>();
            A.CallTo(() => _tasks.GetTaskById(fakeTaskId)).Returns(fake);

            var result = _taskController.GetAllTasks();
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void EFCoreMyApp_AddTask_ReturnSuccess()
        {
            var fakeTask = new TaskObject(10, "Learn new language", false);

            A.CallTo(() => _tasks.GetTaskById(fakeTask.Id)).Returns(null);
            A.CallTo(() => _tasks.AddTask(fakeTask));

            var result = _taskController.AddTask(fakeTask);
            Console.Write(result.ToString());
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void EFCoreMyApp_AddTask_ReturnReject()
        {
            var fakeTask = new TaskObject(1, "Do homework", true);
            var testTask = A.Fake<TaskObject>();

            A.CallTo(() => _tasks.GetTaskById(fakeTask.Id)).Returns(testTask);
            A.CallTo(() => _tasks.AddTask(fakeTask));

            var result = _taskController.AddTask(fakeTask);
            Console.Write(result.ToString());
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void EFCoreMyApp_DeleteTask_ReturnSuccess()
        {
            var fakeTaskId = 3;
            var fake = A.Fake<TaskObject>();
            A.CallTo(() => _tasks.DeleteTask(fakeTaskId)).Returns(fake);

            var result = _taskController.DeleteTask(fakeTaskId);
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void EFCoreMyApp_CompleteTask_ReturnSuccess()
        {
            var fakeTaskId = 1;
            var fake = A.Fake<TaskObject>();
            A.CallTo(() => _tasks.DeleteTask(fakeTaskId)).Returns(fake);

            var result = _taskController.DeleteTask(fakeTaskId);
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
