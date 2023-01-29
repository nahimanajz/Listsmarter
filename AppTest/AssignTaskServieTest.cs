using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;
using CSharp_intro_1.Services.interfaces;
using CSharp_intro_1.Tasks.Business.Services;
using Moq;

namespace App.Tests
{
    public class AssignTaskServieTest
    {
        private readonly Mock<ITaskRepository> _taskRepoMock = new Mock<ITaskRepository>();
        private readonly Mock<IPersonService> _personServiceMock = new Mock<IPersonService>();
        private readonly Mock<ITaskService> _taskServiceMock = new Mock<ITaskService>();
        private readonly AssignTaskService _assignTaskService;
        private TaskDto _task;

        public AssignTaskServieTest()
        {
            _assignTaskService = new AssignTaskService(_taskRepoMock.Object, _personServiceMock.Object, _taskServiceMock.Object);
            _task = new TaskDto
            {
                Title = "Some testing TASK",
                Description = "SOME OTHER CHANGED TASK",
                Status = (int)Status.Open,
                Person = new PersonDto { FirstName = "John", LastName = "Kalisa" },
                Bucket = new BucketDto { Id = Guid.Parse("8D2B0128-5D0D-4C23-9B49-02A698852119"), Title = "Example bucket" }
            };
        }

        [Fact]
        public void AssignTask_GivenValidTaskIdAndPersonId_ThenReturnAssignedTaskData()
        {

            var actualAssignedTask = new TaskDto
            {
                Id = Guid.NewGuid(),
                Title = "Some testing TASK",
                Description = "SOME OTHER CHANGED TASK",
                Status = Status.InProgress,
                Person = new PersonDto { Id = Guid.Parse("8D2B0128-5D0D-4C23-9B49-02A698752111"), FirstName = "John", LastName = "Kalisa" },
                Bucket = new BucketDto { Id = Guid.Parse("8D2B0128-5D0D-4C23-9B49-02A698852119"), Title = "Example bucket" }
            };


            _taskRepoMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(_task);
            _taskRepoMock.Setup(repo => repo.AssignTask(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(new List<TaskDto> { actualAssignedTask });

            var assignedTask = _assignTaskService.AssignTask(actualAssignedTask.Id, actualAssignedTask.Person.Id);

            Assert.NotNull(assignedTask);
            Assert.Equal(assignedTask[0].Id, actualAssignedTask.Id);

        }
    }
}