using AutoFixture;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Tasks.Business.Services;
using Moq;
using FluentAssertions;
using CSharp_intro_1.Common.Business.ResponseMessages;

namespace App.Tests
{
    public class AssignTaskServiceTest
    {
        private readonly Mock<ITaskRepository> _taskRepoMock = new Mock<ITaskRepository>();
        private readonly Mock<IRepository<PersonDto>> _personRepoMock = new Mock<IRepository<PersonDto>>();

        private readonly AssignTaskService _assignTaskService;
        private TaskDto _task;
        private Fixture fixture = new Fixture();
        private Guid defaultTaskId = Guid.Parse("8D2B0128-5D0D-4C23-9B49-02A698852129");


        public AssignTaskServiceTest()
        {
            _assignTaskService = new AssignTaskService(_taskRepoMock.Object);
            _task = fixture.Create<TaskDto>();
            _taskRepoMock.Setup(repo => repo.GetById(defaultTaskId)).Returns(new TaskDto { Id = defaultTaskId });
        }

        [Fact]
        public void AssignTask_GivenValidTaskIdAndPersonId_ReturnAssignedTaskData()
        {

            var actualAssignedTask = fixture.Create<TaskDto>();

            _taskRepoMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(_task);
            _taskRepoMock.Setup(repo => repo.IsPersonExist(It.IsAny<Guid>())).Returns(true);

            _taskRepoMock.Setup(repo => repo.Update(It.IsAny<TaskDto>())).Returns(actualAssignedTask);

            var assignedTask = _assignTaskService.AssignTask(actualAssignedTask.Id, actualAssignedTask.Person.Id);
            assignedTask.Should().NotBeNull();
            assignedTask.Person.Id.Should().Be(actualAssignedTask.Person.Id);


        }

        [Fact]
        public void AssignTask_GivenInValidTaskIdOrPersonId_ThrowException()
        {
            _personRepoMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns<PersonDto>(null);
            _taskRepoMock.Setup(repo => repo.Update(It.IsAny<TaskDto>())).Returns((TaskDto)  null);

            Action action = () => _assignTaskService.AssignTask(Guid.NewGuid(), Guid.NewGuid());
            action.Should().Throw<Exception>().WithMessage(ResponseMessages.TaskOrPersonNotFound);
           
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
