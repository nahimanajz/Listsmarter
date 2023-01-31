using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Repositories.Models;
using CSharp_intro_1.Services;
using CSharp_intro_1.Services.interfaces;
using CSharp_intro_1.Tasks.Business.Services;
using Moq;
using FluentAssertions;

namespace App.Tests
{
    public class AssignTaskServiceTest
    {
        private readonly Mock<ITaskRepository> _taskRepoMock = new Mock<ITaskRepository>();
        private readonly Mock<IRepository<PersonDto>> _personRepoMock = new Mock<IRepository<PersonDto>>();
        private readonly Mock<TaskService> _taskService = new Mock<TaskService>();
        private readonly Mock<PersonService> _personService = new Mock<PersonService>();

        private readonly AssignTaskService _assignTaskService;
        private TaskDto _task;
        private Fixture fixture = new Fixture();
        private Guid defaultTaskId = Guid.Parse("8D2B0128-5D0D-4C23-9B49-02A698852129");


        public AssignTaskServiceTest()
        {
            _assignTaskService = new AssignTaskService(_taskRepoMock.Object);

            _task = new TaskDto
            {
                Title = "Some testing TASK",
                Description = "SOME OTHER CHANGED TASK",
                Status = (int)Status.Open,
                Person = null,
                Bucket = new BucketDto { Id = Guid.Parse("8D2B0128-5D0D-4C23-9B49-02A698852119"), Title = "Example bucket" }
            };


            _taskRepoMock.Setup(repo => repo.GetById(defaultTaskId)).Returns(new TaskDto { Id = defaultTaskId });
        }

        [Fact]
        public void AssignTask_GivenValidTaskIdAndPersonId_ReturnAssignedTaskData()
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
            assignedTask[0].Should().NotBeNull();
            assignedTask[0].Id.Should().Be(actualAssignedTask.Id);


        }

        [Fact]
        public void AssignTask_GivenInValidTaskIdOrPersonId_ThrowException()
        {
            _personRepoMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns<PersonDto>(null);
            _taskRepoMock.Setup(repo => repo.AssignTask(defaultTaskId, defaultTaskId)).Returns(new List<TaskDto> { null });

            Action action = () => _assignTaskService.AssignTask(Guid.NewGuid(), Guid.NewGuid());
            action.Should().Throw<Exception>();
        }


        [Fact]
        public void AssignTask_GivenInValidPersonId_ThrowException()
        {
            _personRepoMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns<PersonDto>(null);

            Action action = () => _assignTaskService.AssignTask(Guid.NewGuid(), Guid.NewGuid());
            action.Should().Throw<Exception>();
        }

    }
}
//      TODO: Using Fixture 
//    Using fluent assertion